namespace Server.Application.Features.Products.GetById;

public sealed record GetProductByIdQueryResult(
    Guid Id,
    string Name,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
