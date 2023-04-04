using AutoMapper;
using MediatR;
using MercadinhoWeb.Application.Queries.Requests;
using MercadinhoWeb.Application.Queries.Responses;
using MercadinhoWeb.Domain.Interfaces.Caching;
using MercadinhoWeb.Domain.Interfaces.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadinhoWeb.Application.Handlers.QueriesHandlers
{
    public class GetProductsRequestHandler : IRequestHandler<GetProductsQuery, IEnumerable<GetProductResponse>>
    {
        private readonly IProductRepository _repository;
        private readonly ICachingService _cachingService;
        private readonly IMapper _mapper;

        public GetProductsRequestHandler(IProductRepository repository, ICachingService cachingService, IMapper mapper)
        {
            _repository = repository;
            _cachingService = cachingService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"products-getAll:{request.Skip}:{request.Take}:{request.SearchTerm}:{request.CategoryId}";
            var getProductsResponseCache = await _cachingService.GetAsync(cacheKey);

            if (!string.IsNullOrEmpty(getProductsResponseCache))
            {
                return JsonConvert.DeserializeObject<IEnumerable<GetProductResponse>>(getProductsResponseCache);
            }

            var products = await _repository.FindAllAsync(request.Skip,request.Take,request.SearchTerm,request.CategoryId);
            var getProductsResponse = _mapper.Map<IEnumerable<GetProductResponse>>(products);
            
            await _cachingService.SetAsync(cacheKey, JsonConvert.SerializeObject(getProductsResponse));

            return getProductsResponse;
        }
    }
}
