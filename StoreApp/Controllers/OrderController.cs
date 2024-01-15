using System.Reflection.Metadata.Ecma335;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers;

public class OrderController : Controller
{
    private readonly IServiceManager _manager;
    private readonly Cart _cart;

    public OrderController(IServiceManager manager, Cart cart)
    {
        _manager = manager;
        _cart = cart;
    }

    public ViewResult Checkout() => View(new Order());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Checkout(Order order)
    {
        if (_cart.Lines.Count.Equals(0))
            ModelState.AddModelError("","Sorry, the cart is empty.");
        if (ModelState.IsValid)
        {
            order.Lines = _cart.Lines;
            _manager.Order.SaveOrder(order);
            _cart.RemoveAll();
            return RedirectToPage("/Congrats" , new {OrderId = order.Id});
        }
        return View();
    }
}