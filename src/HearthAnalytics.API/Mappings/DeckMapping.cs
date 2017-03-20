using AutoMapper;
using HearthAnalytics.API.DataTransferObjects;
using HearthAnalytics.Model;

namespace HearthAnalytics.API.Mappings
{
    public class DeckMapping : Profile
    {
        public DeckMapping()
        {
            CreateMap<Deck, DeckDto>();

            CreateMap<DeckDto, Deck>()
                .ForMember(dest => dest.Id, opts => opts.Ignore())
                .ForMember(dest => dest.ArchyType, opts => opts.Ignore());
        }
    }
}
