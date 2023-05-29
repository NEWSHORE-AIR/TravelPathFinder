namespace TravelPathFinder.Core.Domain
{
    public struct Transport
    {
        public string FlightCarrier { get; }
        public string FlightNumber { get; }

        public Transport(string flightCarrier, string flightNumber)
        {
            FlightCarrier = flightCarrier ?? throw new ArgumentNullException(nameof(flightCarrier));
            FlightNumber = flightNumber ?? throw new ArgumentNullException(nameof(flightNumber));
        }
    }
}
