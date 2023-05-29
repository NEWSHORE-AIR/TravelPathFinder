using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace TravelPathFinder.BlazorApp.Components
{
    public class RouteFinderModel : ComponentBase
    {
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public List<Route> Results { get; set; } = new List<Route>();

        public void ToUpper(ChangeEventArgs e, string field)
        {
            var inputElement = (e.Value as string);

            if (field == "Origin")
            {
                Origin = inputElement?.ToUpper() ?? string.Empty;
            }
            else if (field == "Destination")
            {
                Destination = inputElement?.ToUpper() ?? string.Empty;
            }
        }

        public async Task HandleSubmit()
        {
            if (Origin == Destination)
            {
                // Show error message or perform some action
                return;
            }


            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://travelpathfinderapi.azurewebsites.net/api/Journey/calculate-routes?origin={Origin}&destination={Destination}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Results = JsonSerializer.Deserialize<List<Route>>(json) ?? new List<Route>();

                }
                else
                {
                    throw new Exception("Error al cargar ruta");
                }
            }
        }
    }

public class Route
{
    [JsonPropertyName("flights")]
    public List<Flight> Flights { get; set; } = new List<Flight>();

    [JsonPropertyName("origin")]
    public string Origin { get; set; }=string.Empty;

    [JsonPropertyName("destination")]
    public string Destination { get; set; }=string.Empty;

    [JsonPropertyName("price")]
    public decimal Price { get; set; }
}

public class Flight
{
    [JsonPropertyName("transport")]
    public Transport Transport { get; set; }= new Transport();

    [JsonPropertyName("origin")]
    public string Origin { get; set; } = string.Empty;

    [JsonPropertyName("destination")]
    public string Destination { get; set; }= string.Empty;

    [JsonPropertyName("price")]
    public decimal Price { get; set; }
}

public class Transport
{
    [JsonPropertyName("flightCarrier")]
    public string FlightCarrier { get; set; }=string.Empty;

    [JsonPropertyName("flightNumber")]
    public string FlightNumber { get; set; }=string.Empty;
}

}

