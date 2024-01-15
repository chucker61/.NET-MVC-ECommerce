using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Controllers;

public class ProductController : Controller
{

    private readonly IServiceManager _manager;

    public ProductController(IServiceManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index([FromQuery] ProductRequestParameters parameters)
    {
        var products = _manager.Product.GetAllProductsWithDetails(parameters).ToList();
        Pagination pagination = new(){
            TotalItems = _manager.Product.GetAllProducts(false).Count(),
            ItemsPerPage = parameters.PageSize,
            CurrenPage = parameters.PageNumber
        };
        return View(new ProductListViewModel(){
            Products = products,
            Pagination = pagination
        });
    }

    public IActionResult Get([FromRoute(Name = "id")] int id)
    {
        var model = _manager.Product.GetOneProductById(id, false);
        return View(model);
    }
}
