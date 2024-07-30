using MediatR;

namespace Server.Application.Features.Products.GetById;

public sealed class GetProductByIdQuery : IRequest<GetProductByIdQueryResult>
{
    public GetProductByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
