using MediatR;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Features.Products.Update;

internal sealed class UpdateProductCommandHandler(
    IRepository<Product> repository) : IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByAsync(p => p.Id == request.Id, cancellationToken);
        values.Name = request.Name;
        values.UpdatedAt = DateTime.Now;
        await repository.UpdateAsync(values);
    }
}
