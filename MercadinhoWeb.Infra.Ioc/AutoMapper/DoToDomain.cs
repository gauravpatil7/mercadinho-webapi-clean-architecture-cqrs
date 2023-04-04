using AutoMapper;
using MercadinhoWeb.Application.Commands.Requests;
using MercadinhoWeb.Application.Commands.Responses;
using MercadinhoWeb.Application.Queries.Responses;
using MercadinhoWeb.Domain.Entities;

namespace MercadinhoWeb.Infra.Ioc.AutoMapper;

public class DtoToDomain : Profile
{
    public DtoToDomain()
    {
        #region CreateProductRequest to Product
        
        CreateMap<CreateProductRequest, Product>();

        #endregion

        #region Product to CreateProductResponse

        CreateMap<Product, CreateProductResponse>();

        #endregion

        #region Product to GetProductResponse

        CreateMap<Product, GetProductResponse>()
            .ForMember(x => x.Category, y => y.MapFrom(x => x.Category));

        #endregion

        #region Product to GetProductByIdResponse

        CreateMap<Product, GetProductByIdResponse>()
            .ForMember(x => x.Category, y => y.MapFrom(x => x.Category));

        #endregion

        #region Category to GetCategoryReponse

        CreateMap<Category, GetCategoryReponse>();

        #endregion
    }
}
