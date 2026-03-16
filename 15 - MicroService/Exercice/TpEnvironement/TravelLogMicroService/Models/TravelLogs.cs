namespace TravelLogMicroService.Models;

public class TravelLogs
{
    public int Id { get; set; }
    public int ObservationId { get; set; }
    public double DistanceKm { get; set; }
    public TravelMode TravelMode { get; set; }
    public double EstimatedCO2 { get; set; }

    public void ClalcEstimatedCO2()
    {
        double factor = TravelMode switch
        {
            TravelMode.Walking or TravelMode.Bike => 0,
            TravelMode.Car  =>  0.220,
            TravelMode.Bus  =>  0.110,
            TravelMode.Train =>  0.030,
            TravelMode.Plane => 0.259,
            _ => throw new ArgumentOutOfRangeException()
        };
        EstimatedCO2 = Math.Round(DistanceKm * factor, 3);
    } 
}