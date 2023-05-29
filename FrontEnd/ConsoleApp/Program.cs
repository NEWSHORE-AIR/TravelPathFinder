


/*namespace ConsoleApp
{
    /* class Program
     {
         static async Task Main(string[] args)
         {

             var configuration = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json")
                                 .Build();


             IMemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());

             var flightApiClient = new FlightApiClient(configuration, memoryCache);

             try
             {
                 // Obtiene los vuelos desde el servicio REST
                 var flights = await flightApiClient.GetFlightsAsync();

                 // Imprime los vuelos en la consola
                 Console.WriteLine("Flights:");
                 foreach (var flight in flights)
                 {
                     Console.WriteLine($"Departure: {flight.DepartureStation}");
                     Console.WriteLine($"Arrival: {flight.ArrivalStation}");
                     Console.WriteLine($"Flight Carrier: {flight.FlightCarrier}");
                     Console.WriteLine($"Flight Number: {flight.FlightNumber}");
                     Console.WriteLine($"Price: {flight.Price}");
                     Console.WriteLine();
                 }
             }
             catch (ApiException ex)
             {
                 // Maneja la excepción del servicio REST
                 Console.WriteLine($"Error: {ex.ErrorCode}");
                 Console.WriteLine($"Message: {ex.ErrorMessage}");
             }

             Console.ReadLine();
         }
     }
    class Program
    {
        static void Main(string[] args)
        {
            // Crea la configuración

            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();


            // Crea una instancia de JourneyRouteHandler pasando la configuración
            var journeyRouteHandler = new JourneyRouteHandler(configuration);

            // Ejemplo de uso del método GetNewshoreAirFlightsAsync
            string origin = "MZL";
            string destination = "MDE";
            var flights = journeyRouteHandler.GetNewshoreAirFlightsAsync(origin, destination).Result;

            try
            {
                // Imprime los vuelos en la consola
                Console.WriteLine("Flights:");
                foreach (var flight in flights)
                {
                    Console.WriteLine($"Departure: {flight.DepartureStation}");
                    Console.WriteLine($"Arrival: {flight.ArrivalStation}");
                    Console.WriteLine($"Flight Carrier: {flight.FlightCarrier}");
                    Console.WriteLine($"Flight Number: {flight.FlightNumber}");
                    Console.WriteLine($"Price: {flight.Price}");
                    Console.WriteLine();
                }
            }
            catch (ApiException ex)
            {
                // Maneja la excepción del servicio REST
                Console.WriteLine($"Error: {ex.ErrorCode}");
                Console.WriteLine($"Message: {ex.ErrorMessage}");
            }

            // Espera a que el usuario presione una tecla para salir
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }


using AutoMapper;
using TravelPathFinder.Core.Domain;
using TravelPathFinder.Core.Mappings;
using TravelPathFinder.Infrastructure.Services;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configurar AutoMapper
            IMapper mapper = FlightMapperConfig.Initialize();

            // Obtener una lista de FlightDto
            List<FlightDto> flightDtos = GetFlightDtos();

            // Mapear los FlightDto a entidades Flight
            List<Flight> flights = MapFlightDtosToFlights(flightDtos, mapper);

            // Imprimir los resultados
            Console.WriteLine("Mapeo completado:");
            foreach (var flight in flights)
            {
                Console.WriteLine($"Origin: {flight.Origin}, Destination: {flight.Destination}, Price: {flight.Price},FlightCarrier:{flight.Transport.FlightCarrier},  FlightNumber:{flight.Transport.FlightNumber}");
            }
        }

        private static List<FlightDto> GetFlightDtos()
        {
            // Simulación de datos de DTOs
            var flightDtos = new List<FlightDto>
            {
                new FlightDto { DepartureStation = "Origin1", ArrivalStation = "Destination1", FlightCarrier = "Carrier1", FlightNumber = "123", Price = 100.0 },
                new FlightDto { DepartureStation = "Origin2", ArrivalStation = "Destination2", FlightCarrier = "Carrier2", FlightNumber = "456", Price = 200.0 },
                new FlightDto { DepartureStation = "Origin3", ArrivalStation = "Destination3", FlightCarrier = "Carrier3", FlightNumber = "789", Price = 300.0 }
            };

            return flightDtos;
        }

        private static List<Flight> MapFlightDtosToFlights(List<FlightDto> flightDtos, IMapper mapper)
        {
            List<Flight> flights = mapper.Map<List<Flight>>(flightDtos);
            return flights;
        }
    }
}


*/

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace TravelPathFinder.Core.Domain
{

    public class Program
    {
        public static async Task Main(string[] args)
        {
            string origin = "MZL";
            string destination = "BOG";

            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();


            // Crea una instancia de JourneyRouteHandler pasando la configuración
            var calculator = new JourneyRouteHandler(configuration);
            List<Journey> allRoutes = await calculator.CalculateAllRoutes(origin, destination);

           foreach (Journey journey in allRoutes)
            {
                Console.WriteLine("*******************************************************");
                Console.WriteLine($"Origin: {journey.Origin}, Destination: {journey.Destination}, Price: {journey.Price}");
                Console.WriteLine("Vuelos:");

                foreach (Flight flight in journey.Flights)
                {
                    Console.WriteLine($"Origin: {flight.Origin}, Destination: {flight.Destination}, Price: {flight.Price}");
                }
            }
        }
    }
}








