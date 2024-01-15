using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record ProductDto
{
    public int Id { get; init; }
    [Required(ErrorMessage ="Name is required field.")]
    public string? Name { get; init; }
    [Required(ErrorMessage ="Price is required field.")]
    public decimal Price { get; init; }
    public string? Summary { get; init; } = String.Empty;
    public string? ImagePath { get; set; }
    [Required(ErrorMessage = "Category Name is required field.")]
    public int CategoryId { get; init; }
}