namespace Genius.API.Response;

public class ReservationResponse
{
    public int Id { get; set; }
    public double TotalCost { get; set; }
    public string DueDate { get; set; }
    public string TimeLimit { get; set; }
}