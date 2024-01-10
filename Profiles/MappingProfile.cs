using AutoMapper;
using ProfileService.Data.DTOs;
using ProfileService.Entities;

namespace ProfileService.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, userDTO>().ReverseMap();
        }
    }
}
