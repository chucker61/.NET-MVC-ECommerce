namespace Entities.Models;

public class Cart
{
    public List<CartLine> Lines { get; set; }
    public Cart()
    {
        Lines = new();
    }

    public virtual void AddItem(Product product,int quantity)
    {
        CartLine? line = Lines.Where(l => l.Product.Id.Equals(product.Id)).FirstOrDefault();

        if(line is null)
            Lines.Add(new CartLine(){
                Product = product,
                Quantity = quantity
            });
        else
            line.Quantity += quantity;
    }

    public virtual void RemoveItem(Product product)
    {
        Lines.RemoveAll(l => l.Product.Id.Equals(product.Id));
    }

    public decimal ComputeTotalValue()
    {
        return Lines.Sum(l => l.Product.Price * l.Quantity);
    }

    public virtual void RemoveAll()
    {
        Lines.Clear();
    }
}