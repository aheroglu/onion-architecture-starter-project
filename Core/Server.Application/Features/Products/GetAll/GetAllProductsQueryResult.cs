namespace Server.Application.Features.Products.GetAll;

public sealed record GetAllProductsQueryResult(
    Guid Id,
    string Name,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
