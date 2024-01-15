using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly IServiceManager _manager;

    public ProductController(IServiceManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index()
    {
        var model = _manager.Product.GetAllProducts(false);
        return View(model);
    }

    public IActionResult Create()
    {
        ViewBag.Categories = GetCategoriesSelectList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] ProductDtoForInsertions productDto, IFormFile file)
    {
        if (ModelState.IsValid)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            
            productDto.ImagePath = String.Concat("/images/", file.FileName);
            _manager.Product.CreateOneProduct(productDto);
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Update(int id)
    {
        ViewBag.Categories = GetCategoriesSelectList();
        var model = _manager.Product.GetOneProductForUpdate(id, false);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file)
    {
        if (ModelState.IsValid)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            
            productDto.ImagePath = String.Concat("/images/", file.FileName);
            _manager.Product.UpdateOneProduct(productDto);
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Delete(int id)
    {
        _manager.Product.DeleteOneProduct(id);
        return RedirectToAction("Index");
    }

    private SelectList GetCategoriesSelectList()
    {
        return new SelectList(_manager.Category.GetAllCategories(false), "Id", "Name", "1");
    }
}