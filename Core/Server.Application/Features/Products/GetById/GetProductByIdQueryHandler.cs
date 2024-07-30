using MediatR;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Features.Products.GetById;

internal sealed class GetProductByIdQueryHandler(
    IRepository<Product> repository) : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
{
    public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await repository.GetByAsync(p => p.Id == request.Id, cancellationToken);
        return new GetProductByIdQueryResult(
            response.Id,
            response.Name,
            response.CreatedAt,
            response.UpdatedAt);
    }
}
