using AutoMapper;
using Kwitter.DTOs;
using Kwitter.Models;

namespace Kwitter.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
        }
    }
}