using AppModels.approval;
using godown.DomainModels;
using AutoMapper;
using AppModels.godown;

namespace godown
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ApplicationFormDto, ApplicationForm>().ReverseMap();
            CreateMap<ApplicationFormDetailDto, ApplicationFormDetail>().ReverseMap();
        }
    }
}
