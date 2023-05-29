using AutoMapper;
using TravelPathFinder.Core.Domain;
using TravelPathFinder.Infrastructure.Services;

namespace TravelPathFinder.Core.Mappings
{
    public class FlightMapperConfig
    {
        public static IMapper Initialize()
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<FlightDto, Flight>()
                    .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => src.DepartureStation))
                    .ForMember(dest => dest.Destination, opt => opt.MapFrom(src => src.ArrivalStation))
                    .ForMember(dest => dest.Transport, opt => opt.MapFrom(src => new Transport(src.FlightCarrier, src.FlightNumber)));
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            return mapper;
        }
    }
}
