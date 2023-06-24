using Genius.Infraestructure.Shared;

namespace Genius.Infraestructure.Models;

public class PaymentMethod: BaseModel
{
    public string TypePayement { get; set; }
    public string NamePayement { get; set; }
    public int CodePayement { get; set; }
    public  List<Parking> Parkings { get; set; } //  tengo una lista de cars el modelo driver
 

}