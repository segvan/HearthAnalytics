using AutoMapper;
using HearthAnalytics.API.DataTransferObjects;
using HearthAnalytics.Model;

namespace HearthAnalytics.API.Mappings
{
    public class MatchResultMapping : Profile
    {
        public MatchResultMapping()
        {
            CreateMap<MatchResult, MatchResultDto>().ReverseMap();
        }
    }
}
