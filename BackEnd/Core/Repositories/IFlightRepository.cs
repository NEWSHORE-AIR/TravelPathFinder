using TravelPathFinder.Infrastructure.Services;

namespace TravelPathFinder.Core.Repositories
{
    public interface IFlightRepository
    {
        Task<List<FlightDto>> GetFlightsAsync();
    }
}