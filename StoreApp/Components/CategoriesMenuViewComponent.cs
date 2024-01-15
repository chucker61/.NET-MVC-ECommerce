using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components;

public class CategoriesMenuViewComponent : ViewComponent
{
    private readonly IServiceManager _manager;

    public CategoriesMenuViewComponent(IServiceManager serviceManager)
    {
        _manager = serviceManager;
    }

    public IViewComponentResult Invoke()
    {
        var categories = _manager.Category.GetAllCategories(false);
        return View(categories);
    }
}