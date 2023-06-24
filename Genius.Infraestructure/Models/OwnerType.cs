using Genius.Infraestructure.Shared;

namespace Genius.Infraestructure.Models;

public class OwnerType:BaseModel
{
    
    public string NameType { get; set; }
    public  List<Owner> Owners { get; set; }
    
}