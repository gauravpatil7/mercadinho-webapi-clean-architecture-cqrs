using AutoMapper;
using MediatR;
using MercadinhoWeb.Application.Commands.Requests;
using MercadinhoWeb.Application.Commands.Responses;
using MercadinhoWeb.Domain.Entities;
using MercadinhoWeb.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadinhoWeb.Application.Handlers.CommandHandlers;

public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public CreateProductRequestHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        Product prod = _mapper.Map<Product>(request);
        prod.Id = Guid.NewGuid();
        prod.CreatedDate= DateTime.Now;

        await _repository.SaveAsync(prod);

        return _mapper.Map<CreateProductResponse>(prod);
    }
}
