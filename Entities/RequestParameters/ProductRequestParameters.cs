namespace Entities.RequestParameters;

public class ProductRequestParameters : BaseRequestParameters
{
    public int? CategoryId { get; set; } 
    public int? MinPrice { get; set; }
    public int? MaxPrice { get; set; }
    public bool IsValidPrice => MaxPrice > MinPrice;   
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public ProductRequestParameters(): this(1,6)
    {
        
    }
    
    public ProductRequestParameters(int pageNumber=1, int pageSize=6)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}