namespace TravelPathFinder.Core.Domain
{
    public class Flight
    {
        public Transport Transport { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }

        public Flight()
        {
            Origin = string.Empty;
            Destination=string.Empty;
        }
        public Flight(string origin, string destination, double price, string flightCarrier, string flightNumber)
        {
            Origin = origin ?? throw new ArgumentNullException(nameof(origin));
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            Price = price;
            Transport = new Transport(flightCarrier, flightNumber);
        }

    }

}