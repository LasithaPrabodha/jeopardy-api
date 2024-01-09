using AutoMapper;
using Jeopardy.API.DTO;
using Jeopardy.API.Models;

namespace Jeopardy.API.Helpers;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CategoryDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName));
    }
}