using AppModels.basicinfo;
using AutoMapper;
using portal.ViewModels;

namespace portal
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductDto, ProductItem>().ReverseMap();
            CreateMap<ProductItem, ProductAddInput>().ReverseMap();
            CreateMap<ProductItem, ProductUpdateInput>().ReverseMap();
        }
    }
}
