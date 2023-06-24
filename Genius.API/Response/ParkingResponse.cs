namespace Genius.API.Response;

public class ParkingResponse
{
    public int Id { get; set; }
    public double CostPerHour { get; set; }
    public double PenaltyFee { get; set; }
    public string Address { get; set; }
    public int TotalSpace { get; set; }
    public string OpeningTime { get; set; }
    public string ClosingTime { get; set; }
}