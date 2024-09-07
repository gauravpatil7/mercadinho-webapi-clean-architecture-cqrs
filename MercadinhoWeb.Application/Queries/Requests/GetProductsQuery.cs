namespace MercadinhoWeb.Application.Queries.Requests
{
    public record GetProductsQuery : IRequest<IEnumerable<GetProductResponse>>
    {
        public string SearchTerm { get; init; } = string.Empty;
        public string CategoryId { get; init; } = string.Empty;
        public int Take { get; init; } = 15;
        public int Skip { get; init; } = 0;
    }
}
