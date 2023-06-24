using Genius.Infraestructure.Shared;

namespace Genius.Infraestructure.Models;

public class Driver : BaseModel
{ 
    public string Name { get; set; }
    public int Age { get; set; }
    public string License { get; set; }
    public string Phone { get; set; }
    
    public  List<Car> Cars { get; set; } //  tengo una lista de cars el modelo driver
    public  List<Reservation> Reservations { get; set; }
    
   // public bool IsActive { get; set; }

}