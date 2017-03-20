using AutoMapper;
using HearthAnalytics.API.DataTransferObjects;
using HearthAnalytics.Model;

namespace HearthAnalytics.API.Mappings
{
    public class MatchMapping : Profile
    {
        public MatchMapping()
        {
            CreateMap<Match, MatchDto>();

            CreateMap<MatchDto, Match>()
                .ForMember(dest => dest.Id, opts => opts.Ignore())
                .ForMember(dest => dest.Deck, opts => opts.Ignore())
                .ForMember(dest => dest.EnemyArchyType, opts => opts.Ignore())
                .ForMember(dest => dest.Owner, opts => opts.Ignore())
                .ForMember(dest => dest.EnemyClassId, opts => opts.Condition(x => x.EnemyClassId > 0))
                .ForMember(dest => dest.EnemyArchyTypeId, opts => opts.Condition(x => x.EnemyArchyTypeId > 0));
        }
    }
}
