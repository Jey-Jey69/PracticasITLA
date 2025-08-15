using AutoMapper;
using PlantasOrnamentales.Application.DTOs;
using PlantasOrnamentales.Domain.Entities;

namespace PlantasOrnamentales.Application.MappingProfiles
{
    public class PlantaProfile : Profile
    {
        public PlantaProfile()
        {
            CreateMap<Planta, PlantaReadDto>().ReverseMap();
            CreateMap<PlantaCreateDto, Planta>();
            CreateMap<PlantaUpdateDto, Planta>();
        }
    }
}
