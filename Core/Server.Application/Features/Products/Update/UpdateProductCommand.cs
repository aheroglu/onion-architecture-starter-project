using MediatR;

namespace Server.Application.Features.Products.Update;

public sealed record UpdateProductCommand(
    Guid Id,
    string Name) : IRequest;
