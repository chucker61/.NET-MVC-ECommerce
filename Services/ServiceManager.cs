using Services.Contracts;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    private readonly IOrderService _orderService;

    public ServiceManager(ICategoryService categoryService, IProductService productService, IOrderService orderService)
    {
        _categoryService = categoryService;
        _productService = productService;
        _orderService = orderService;
    }

    public ICategoryService Category => _categoryService;

    public IProductService Product => _productService;

    public IOrderService Order => _orderService;
}