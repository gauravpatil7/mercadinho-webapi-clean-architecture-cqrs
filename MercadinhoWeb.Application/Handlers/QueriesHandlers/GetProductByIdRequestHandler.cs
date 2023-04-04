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

namespace MercadinhoWeb.Application.Handlers.QueriesHandlers;

public class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdResponse>
{
    private readonly IProductRepository _repository;
    private readonly ICachingService _cachingService;
    private readonly IMapper _mapper;

    public GetProductByIdRequestHandler(IProductRepository repository, ICachingService cachingService, IMapper mapper)
    {
        _repository = repository;
        _cachingService = cachingService;
        _mapper = mapper;
    }
    public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"products-getById:{request.Id}";
        var getProductByIdResponseCache = await _cachingService.GetAsync(cacheKey);

        if (!string.IsNullOrEmpty(getProductByIdResponseCache))
        {
            return JsonConvert.DeserializeObject<GetProductByIdResponse>(getProductByIdResponseCache);
        }
        var prod = await _repository.FindByIdAsync(request.Id);
        var getProductByIdResponse = _mapper.Map<GetProductByIdResponse>(prod);

        await _cachingService.SetAsync(cacheKey, JsonConvert.SerializeObject(getProductByIdResponse));

        return getProductByIdResponse;
    }
}
