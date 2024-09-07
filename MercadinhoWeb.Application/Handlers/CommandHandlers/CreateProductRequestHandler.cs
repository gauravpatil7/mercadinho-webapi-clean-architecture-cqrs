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

        await _repository.SaveAsync(prod);

        return _mapper.Map<CreateProductResponse>(prod);
    }
}
