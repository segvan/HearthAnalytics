using AutoMapper;
using HearthAnalytics.API.DataTransferObjects;
using HearthAnalytics.Model;

namespace HearthAnalytics.API.Mappings
{
    public class ClassTypeMapping : Profile
    {
        public ClassTypeMapping()
        {
            CreateMap<ClassType, ClassTypeDto>().ReverseMap();
        }
    }
}
