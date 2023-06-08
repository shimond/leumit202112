using AutoMapper;
using project_intro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_intro.Mappings
{
    public class ProductMappingConfig : Profile
    {
        public ProductMappingConfig()
        {
            CreateMap<Product, ProductDTO>()
                .ForCtorParam("Name", opt => opt.MapFrom(src => src.ProductName))
                .ForCtorParam("Price", opt => opt.MapFrom(src => src.ProductPrice))
                .ForCtorParam("Id", opt => opt.MapFrom(src => src.ProductId));


            CreateMap<ProductDTO, Product>()
                    .ForMember(x => x.ProductName, opt => opt.MapFrom(src => src.Name))
                    .ForMember(x => x.ProductPrice, opt => opt.MapFrom(src => src.Price))
                    .ForMember(x => x.ProductId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
