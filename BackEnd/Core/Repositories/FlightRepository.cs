using TravelPathFinder.Infrastructure.Services;

namespace TravelPathFinder.Core.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightApiClient _flightApiClient;

        public FlightRepository(FlightApiClient flightApiClient)
        {
            _flightApiClient = flightApiClient;
        }

        public async Task<List<FlightDto>> GetFlightsAsync()
        {
            return await _flightApiClient.GetFlightsAsync();
        }
    }
}
