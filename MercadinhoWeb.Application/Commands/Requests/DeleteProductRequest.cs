namespace MercadinhoWeb.Application.Commands.Requests
{
    public record DeleteProductRequest : IRequest
    {
        public Guid Id { get; init; }
    }
}
