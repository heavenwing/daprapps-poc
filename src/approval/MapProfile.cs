using AppModels.approval;
using approval.DomainModels;
using AutoMapper;

namespace approval
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ApprovalTodo, TodoListDto>().ReverseMap();
        }
    }
}
