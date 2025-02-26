using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace Mission8_0206.Models;

public class Task
{
    // Make Task and Quadrant required. 
    [Key]
    public int TaskId { get; set; }
    
    [Required(ErrorMessage = "Please enter the task name")]
    // Verifies length isn't too long for database storage and displaying on quandrants page
    [MaxLength(30, ErrorMessage = "Maximum length 30 characters")]
    public string? TaskName { get; set; }
    
    public DateTime DueDate { get; set; }
    
    [Required(ErrorMessage = "Please enter valid quadrant for the task")]
    [Range(1,4, ErrorMessage = "The form isn't changing entry to integer values 1-4")]
    public int Quadrant { get; set; }
    
    // Connects the Task table to the Cateogry table based on the model using the correct FK relationship
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    
    public bool? Completed { get; set; }
    
}