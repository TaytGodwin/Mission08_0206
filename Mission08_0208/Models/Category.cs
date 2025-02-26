using System.ComponentModel.DataAnnotations;

namespace Mission8_0206.Models;

public class Category
{
    
    // Basic model for db table for categories
    [Key]
    [Required]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}