using MediatR;
using MercadinhoWeb.Application.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadinhoWeb.Application.Queries.Requests
{
    public class GetProductsQuery : IRequest<IEnumerable<GetProductResponse>>
    {
        public string SearchTerm { get; set; } = string.Empty;
        public string CategoryId { get; set; } = string.Empty;
        public int Take { get; set; } = 15;
        public int Skip { get; set; } = 0;
    }
}
