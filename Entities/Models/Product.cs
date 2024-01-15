using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Product
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required.")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Price is required.")]
    public decimal Price { get; set; }
    public string? Summary { get; set; } = String.Empty;
    public string? ImagePath { get; set; }
    public int CategoryId { get; set; }   //foreign key
    public bool ShowCase { get; set; }

    public Category? Category { get; set; }   //navigation property  
}