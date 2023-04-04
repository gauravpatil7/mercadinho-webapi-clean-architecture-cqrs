using MediatR;
using MercadinhoWeb.Application.Commands.Responses;

namespace MercadinhoWeb.Application.Commands.Requests;

public class CreateProductRequest : IRequest<CreateProductResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public bool Status { get; set; }
    public Guid CategoryId { get; set; }
}
