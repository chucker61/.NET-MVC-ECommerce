using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers;

[Area("Admin")]
public class OrderController : Controller
{
    private readonly IServiceManager _manager;

    public OrderController(IServiceManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index()
    {
        var orders = _manager.Order.Orders(false);
        return View(orders);
    }

    [HttpPost]
    public IActionResult Complete([FromForm] int id)
    {
        _manager.Order.Complete(id,true);
        return RedirectToAction("Index");
    }
}