using Genius.Infraestructure.Shared;

namespace Genius.Infraestructure;

public class Owner: BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    //public  List<Parking> Parkings { get; set; } //  tengo una lista de cars el modelo driver
    
}