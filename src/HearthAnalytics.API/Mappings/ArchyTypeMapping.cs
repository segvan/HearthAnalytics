using AutoMapper;
using HearthAnalytics.API.DataTransferObjects;
using HearthAnalytics.Model;

namespace HearthAnalytics.API.Mappings
{
    public class ArchyTypeMapping : Profile
    {
        public ArchyTypeMapping()
        {
            CreateMap<ArchyType, ArchyTypeDto>();

            CreateMap<ArchyTypeDto, ArchyType>()
                .ForMember(dest => dest.Id, opts => opts.Ignore())
                .ForMember(dest => dest.Class, opts => opts.Ignore());
        }
    }
}
