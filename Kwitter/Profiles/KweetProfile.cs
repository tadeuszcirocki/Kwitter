using AutoMapper;
using Kwitter.DTOs;
using Kwitter.Models;

namespace Kwitter.Profiles
{
    public class KweetProfile : Profile
    {
        public KweetProfile()
        {
            CreateMap<Kweet, KweetReadDto>();
            CreateMap<KweetCreateDto, Kweet>();
            CreateMap<KweetUpdateDto, Kweet>();
            CreateMap<Kweet, KweetUpdateDto>();
        }
    }
}