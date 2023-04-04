using MediatR;
using MercadinhoWeb.Application.Queries.Responses;

namespace MercadinhoWeb.Application.Queries.Requests
{
    public class GetProductByIdQuery : IRequest<GetProductByIdResponse>   
    {
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
