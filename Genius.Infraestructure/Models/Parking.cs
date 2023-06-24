using Genius.Infraestructure.Shared;

namespace Genius.Infraestructure.Models;

public class Parking : BaseModel
{
    public double CostPerHour { get; set; }
    public double PenaltyFee { get; set; }
    public string Address { get; set; }
    public int TotalSpace { get; set; }
    public string OpeningTime { get; set; }
    public string ClosingTime { get; set; }
    public  List<Reservation> Reservations { get; set; }
    public  List<Place> Places { get; set; }
    
}