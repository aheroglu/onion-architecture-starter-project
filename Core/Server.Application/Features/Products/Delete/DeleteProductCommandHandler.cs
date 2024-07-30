using MediatR;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Features.Products.Delete;

internal sealed class DeleteProductCommandHandler(
    IRepository<Product> repository) : IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByAsync(p => p.Id == request.Id, cancellationToken);
        await repository.DeleteAsync(values);
    }
}
