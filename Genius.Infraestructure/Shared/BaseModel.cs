namespace Genius.Infraestructure.Shared;

public class BaseModel
{
    //Campo de auditoria
    public int Id { get; set; }
    public bool IsActive { get; set; }
    
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; } //? -> PARA QUE ACEPTE NULOS
}