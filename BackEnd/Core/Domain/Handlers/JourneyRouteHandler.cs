using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using TravelPathFinder.Core.Mappings;
using TravelPathFinder.Infrastructure.Services;

namespace TravelPathFinder.Core.Domain
{
    public class JourneyRouteHandler : IJourneyRoute
    {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;
        private List<Flight> flights = new List<Flight>();


        public JourneyRouteHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
        }
        public async Task<List<Journey>> CalculateAllRoutes(string origin, string destination)
        {
            List<Journey> allRoutes = new List<Journey>();
            List<Flight> currentRoute = new List<Flight>();
            HashSet<string> visitedAirports = new HashSet<string>();

            List<FlightDto> flightDtos = await GetNewshoreAirFlightsAsync();
            flights = MapFlightDtosToFlights(flightDtos);

            FindRoutesDFS(origin, destination, currentRoute, allRoutes, visitedAirports);

            return allRoutes;

        }


        private void FindRoutesDFS(string currentAirport, string destination, List<Flight> currentRoute, List<Journey> allRoutes, HashSet<string> visitedAirports)
        {
            if (currentAirport == destination)
            {
                Journey journey = new Journey(currentRoute.First().Origin, currentAirport, currentRoute.Sum(f => f.Price), currentRoute.ToList());
                journey.Flights.AddRange(currentRoute);
                allRoutes.Add(journey);
                return;
            }

            visitedAirports.Add(currentAirport);

            List<Flight> availableFlights = flights.Where(f => f.Origin == currentAirport && !visitedAirports.Contains(f.Destination)).ToList();

            foreach (Flight flight in availableFlights)
            {
                currentRoute.Add(flight);

                FindRoutesDFS(flight.Destination, destination, currentRoute, allRoutes, visitedAirports);

                currentRoute.RemoveAt(currentRoute.Count - 1);
            }

            visitedAirports.Remove(currentAirport);
        }




        public async Task<List<FlightDto>> GetNewshoreAirFlightsAsync()
        {

            try
            {

                var flightApiClient = new FlightApiClient(_configuration, _memoryCache);
                var flights = await flightApiClient.GetFlightsAsync();
                return flights;
            }

            catch (ApiException ex)
            {
                throw ex;
            }

        }




        public List<Flight> MapFlightDtosToFlights(List<FlightDto> flightDtos)
        {

            IMapper _mapper = FlightMapperConfig.Initialize();
            List<Flight> flights = _mapper.Map<List<Flight>>(flightDtos);
            return flights;
        }


    }
}
