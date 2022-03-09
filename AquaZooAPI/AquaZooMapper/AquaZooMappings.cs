using AquaZooAPI.Models;
using AquaZooAPI.Models.DataTransfer;
using AutoMapper;

namespace AquaZooAPI.AquaZooMapper
{
    public class AquaZooMappings:Profile
    {
        public AquaZooMappings()
        {
            CreateMap<AquaZooEntity, AquaZooEntityDto>().ReverseMap();
            CreateMap<LocationProgramEntity, LocationProgramEntityDto>().ReverseMap();
            CreateMap<LocationProgramEntity, LocationProgramCreateDto>().ReverseMap();
            CreateMap<LocationProgramEntity, LocationProgramUpdateDto>().ReverseMap();

        }
    }
}
