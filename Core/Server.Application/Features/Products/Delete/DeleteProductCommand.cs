using MediatR;

namespace Server.Application.Features.Products.Delete;

public sealed record DeleteProductCommand(
    Guid Id) : IRequest;
