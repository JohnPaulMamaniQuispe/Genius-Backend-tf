using Genius.Infraestructure.Shared;

namespace Genius.Infraestructure.Models;

public class Car : BaseModel
{
    public int Id { get; set; }
    public string Modelo { get; set; }
    public string Placa { get; set; }
   //public bool IsActive { get; set; }
    
}