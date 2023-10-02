using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace api.Dto.Box;

public class PostBoxDto
{
    [NotNull]
    [Required]
    [StringLength(30, MinimumLength = 5)]
    public string? Title { get; set; }
    
    [NotNull]
    [Required]
    [StringLength(1000, MinimumLength = 1)]
    public string? Type { get; set; }
    
    [NotNull]
    [Required]
    [Url]
    public string? Image { get; set; }
    
    [NotNull]
    [Required(ErrorMessage = "Must be")]
    [RegularExpression("^(Red|Orange|White|Black)$")]
    public string? Color { get; set; }
    
    [NotNull]
    [Required(ErrorMessage = "Must be")]
    [RegularExpression("^(New|Damaged|Old)$")]
    public string? Status { get; set; } 
    
    [NotNull]
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string? Description { get; set; }
    
    [NotNull]
    [Required]
    public decimal Price { get; set; } 
}