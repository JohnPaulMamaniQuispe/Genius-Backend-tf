namespace Genius.API.Input;

public class ParkingInput
{
    public double CostPerHour { get; set; }
    public double PenaltyFee { get; set; }
    public string Address { get; set; }
    public int TotalSpace { get; set; }
    public string OpeningTime { get; set; }
    public string ClosingTime { get; set; }
}