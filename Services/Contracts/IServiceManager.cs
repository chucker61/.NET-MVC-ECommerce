using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Services.Contracts;

public interface IServiceManager
{
    ICategoryService Category { get; }
    IProductService Product { get; }
    IOrderService Order { get; }
}