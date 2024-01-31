using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternDemo.Models;

public class Product
{
	[Key]
	public int Id { get; set; }
	public string Title { get; set; } = null!;

	public string? Category { get; set; }

	public decimal Price { get; set; }

}
