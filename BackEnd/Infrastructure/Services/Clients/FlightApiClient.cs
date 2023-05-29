using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace TravelPathFinder.Infrastructure.Services
{
    public class FlightApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;

        public FlightApiClient(IConfiguration configuration, IMemoryCache cache)
        {

            _configuration = configuration;
            _cache = cache;
        }

        public async Task<List<FlightDto>> GetFlightsAsync()
        {
            string cacheKey = "Flights";
            if (!_cache.TryGetValue(cacheKey, out List<FlightDto>? flights))
            {


                using (HttpClient client = new HttpClient())
                {


                    string apiUrl = _configuration["ApiUrl"]!;

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();

                        if (!string.IsNullOrEmpty(responseContent))
                        {
                            flights = JsonConvert.DeserializeObject<List<FlightDto>>(responseContent)!;
                            var cacheOptions = new MemoryCacheEntryOptions
                            {
                                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                            };

                            _cache.Set(cacheKey, flights, cacheOptions);

                            return flights;
                        }
                    }
                    else
                    {
                        throw new ApiException("Error en la solicitud al servicio REST", response.StatusCode);

                    }
                }
            }
            return flights ?? new List<FlightDto>();
        }

    }
}