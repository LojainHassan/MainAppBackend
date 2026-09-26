using AutoMapper;
using MainAppBackend.Application.Dtos.ClientLookup;
using MainAppBackend.Application.Dtos.Product.ProductCategory;
using MainAppBackend.Domain.Entities.ClientLookup;
using MainAppBackend.Domain.Entities.Product;

namespace MainAppBackend.Application.Mappings;

public class ProductCategoryProfile : Profile
{
    public ProductCategoryProfile()
    {
        CreateMap<ProductCategoryCreateDto, ProductCategory>().ReverseMap();
        CreateMap<ProductCategory, ProductCategoryListDto>().ReverseMap();
        CreateMap<UpdateCreateClientLookupDto, ClientLookup>().ReverseMap();
        CreateMap<ClientLookup, ClientLookupDto>().ReverseMap();
    }
}