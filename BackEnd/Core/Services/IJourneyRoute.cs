namespace TravelPathFinder.Core.Domain
{
public interface IJourneyRoute
{
    Task<List<Journey>> CalculateAllRoutes(string origin, string destination);
    
}

}