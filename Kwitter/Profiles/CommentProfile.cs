using AutoMapper;
using Kwitter.DTOs;
using Kwitter.Models;

namespace Kwitter.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentReadDto>();
        }
    }
}