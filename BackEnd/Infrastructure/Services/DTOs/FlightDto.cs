namespace TravelPathFinder.Infrastructure.Services
{
    public class FlightDto
    {
        public string DepartureStation { get; set; } = string.Empty;
        public string ArrivalStation { get; set; } = string.Empty;
        public string FlightCarrier { get; set; } = string.Empty;
        public string FlightNumber { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}