using Genius.Infraestructure.Shared;

namespace Genius.API.Response;

public class CarResponse: BaseModel
{
    public int Id { get; set; }
    public string Modelo { get; set; }
    public string Placa { get; set; }
    
    
}