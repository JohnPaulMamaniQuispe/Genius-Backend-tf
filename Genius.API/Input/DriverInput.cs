using System.ComponentModel.DataAnnotations;

namespace Genius.API.Input;

public class DriverInput
{
    [Required]
    [MaxLength(20)]
    [MinLength(3)]
    public string Name { get; set; }

    public int Age { get; set; }

    public string License { get; set; }

    public string Phone { get; set; }
    
}