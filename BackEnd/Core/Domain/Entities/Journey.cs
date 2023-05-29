namespace TravelPathFinder.Core.Domain
{
    public class Journey
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }

        
        public Journey(string origin, string destination, double price, List<Flight> flights)
        {
            Origin = origin ?? throw new ArgumentNullException(nameof(origin));
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            Price=price;
           
        }

    }

}