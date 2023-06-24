using Genius.Infraestructure.Shared;

namespace Genius.Infraestructure.Models;

public class Reservation :BaseModel
{
    public double TotalCost { get; set; }
    public string DueDate { get; set; }
    public string TimeLimit { get; set; }
    
}