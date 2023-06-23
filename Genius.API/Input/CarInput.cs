using System.ComponentModel.DataAnnotations;
namespace Genius.API.Input;

public class CarInput
{
    
    
    [Required]
    [MaxLength(10)]
    [MinLength(3)]
    public string Modelo { get; set; }
    
    public string Placa { get; set; }
    
    
}