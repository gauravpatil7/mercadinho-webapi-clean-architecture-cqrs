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
