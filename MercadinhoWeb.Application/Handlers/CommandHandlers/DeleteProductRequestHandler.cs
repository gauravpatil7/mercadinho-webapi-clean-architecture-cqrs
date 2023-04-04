using AutoMapper;
using MediatR;
using MercadinhoWeb.Application.Commands.Requests;
using MercadinhoWeb.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadinhoWeb.Application.Handlers.CommandHandlers
{
    public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest>
    {
        private readonly IProductRepository _repository;
        public DeleteProductRequestHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
