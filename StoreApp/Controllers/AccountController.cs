using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Login([FromQuery] string returnUrl = "/")
    {
        return View(new LoginModel(){
            ReturnUrl = returnUrl
        });
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public  async Task<IActionResult> Login([FromForm] LoginModel model)
    {
        if(ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.EMail);
            if(user is not null)
            {
                await _signInManager.SignOutAsync();

                var result = await _signInManager.PasswordSignInAsync(user,model.Password,false,false);
                if(result.Succeeded)
                {
                    return Redirect(model.ReturnUrl);
                }
            }
            ModelState.AddModelError("Error","Invalid E-Mail or password.");
        }
        return View();
    }

    public async Task<IActionResult> Logout([FromQuery] string returnUrl = "/")
    {
        await _signInManager.SignOutAsync();
        return Redirect(returnUrl);
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register([FromForm] RegisterDto model)
    {
        if(ModelState.IsValid)
        {
            var user = new IdentityUser(){
                UserName = model.UserName,
                Email = model.EMail,
            };
            var result = await _userManager.CreateAsync(user,model.Password);
            if(result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user,"User");
                if(roleResult.Succeeded)
                {
                    return RedirectToAction("Login",new {
                        ReturnUrl = "/"
                    });
                }
            }
            else
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("",err.Description);
                }
            }
            return View();
        }
        return View();
    }
}
