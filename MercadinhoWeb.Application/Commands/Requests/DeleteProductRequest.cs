using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadinhoWeb.Application.Commands.Requests
{
    public class DeleteProductRequest : IRequest
    {
        public Guid Id { get; set; }
    }
}
