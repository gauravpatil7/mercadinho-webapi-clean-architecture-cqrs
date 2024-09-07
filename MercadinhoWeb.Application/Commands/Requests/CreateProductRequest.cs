namespace MercadinhoWeb.Application.Commands.Requests;

public record CreateProductRequest : IRequest<CreateProductResponse>
{
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public int Stock { get; init; }
    public bool Status { get; init; }
    public Guid CategoryId { get; init; }
}
