using System.Globalization;
using AutoMapper;
using Jeopardy.API.Dto;
using Jeopardy.Core.Models;

namespace Jeopardy.API.Helpers;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CategoryDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName));
        CreateMap<Clue, ClueDto>()
            .ForMember(dest => dest.Clue, opt => opt.MapFrom(src => src.IdNavigation.Clue))
            .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.IdNavigation.Answer))
            .ForMember(dest => dest.AirDate, opt => opt.MapFrom(src => src.GameNavigation != null 
                ? src.GameNavigation.Date!.Value.ToString("o", CultureInfo.InvariantCulture) 
                : null));
    }
}