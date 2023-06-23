using Genius.Infraestructure.Shared;

namespace Genius.Infraestructure.Models;

public class Driver : BaseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string License { get; set; }
    public string Phone { get; set; }
    
    public  List<Car> Cars { get; set; } //  tengo una lista de cars el modelo driver
    
    
   // public bool IsActive { get; set; }

}