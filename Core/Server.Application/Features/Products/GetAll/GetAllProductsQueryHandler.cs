using MediatR;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Features.Products.GetAll;

internal sealed class GetAllProductsQueryHandler(
    IRepository<Product> repository) : IRequestHandler<GetAllProductsQuery, List<GetAllProductsQueryResult>>
{
    public async Task<List<GetAllProductsQueryResult>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var response = await repository.GetAllAsync(cancellationToken);
        return response
            .Select(p => new GetAllProductsQueryResult(
                p.Id,
                p.Name,
                p.CreatedAt,
                p.UpdatedAt))
            .ToList();
    }
}
