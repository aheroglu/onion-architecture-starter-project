using MediatR;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Features.Products.Create;

internal sealed class CreateProductCommandHandler(
    IRepository<Product> repository) : IRequestHandler<CreateProductCommand>
{
    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await repository.AddAsync(new Product
        {
            Name = request.Name,
            CreatedAt = DateTime.Now,
        }, cancellationToken);
    }
}
