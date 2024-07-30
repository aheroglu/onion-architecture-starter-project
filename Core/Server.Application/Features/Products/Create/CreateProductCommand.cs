using MediatR;

namespace Server.Application.Features.Products.Create;

public sealed record CreateProductCommand(
    string Name) : IRequest;
