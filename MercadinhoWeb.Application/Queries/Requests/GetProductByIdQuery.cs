namespace MercadinhoWeb.Application.Queries.Requests
{
    public record GetProductByIdQuery : IRequest<GetProductByIdResponse>   
    {
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; init; }
    }
}
