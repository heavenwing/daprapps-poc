using AppModels.approval;
using AutoMapper;
using AppModels.godown;
using godown.DomainModels;

namespace godown
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ApplicationOrderDto, ApplicationOrder>().ReverseMap();
            CreateMap<ApplicationOrderCreateInput, ApplicationOrder>().ReverseMap();
            CreateMap<ApplicationOrderDetailDto, ApplicationOrderDetail>().ReverseMap();
            CreateMap<ApplicationOrder, ApplicationOrderLoadOutput>().ReverseMap();

            CreateMap<ReceiptOrderDto, ReceiptOrder>().ReverseMap();
            CreateMap<ReceiptOrderCreateInput, ReceiptOrder>().ReverseMap();
            CreateMap<ReceiptOrderDetailDto, ReceiptOrderDetail>().ReverseMap();
            CreateMap<ReceiptOrder, ReceiptOrderLoadOutput>().ReverseMap();

            CreateMap<StorageOrderDto, StorageOrder>().ReverseMap();
            CreateMap<StorageOrderCreateInput, StorageOrder>().ReverseMap();
            CreateMap<StorageOrderDetailDto, StorageOrderDetail>().ReverseMap();
            CreateMap<StorageOrder, StorageOrderLoadOutput>().ReverseMap();
        }
    }
}
