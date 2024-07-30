using MediatR;

namespace Server.Application.Features.Products.GetAll;

public sealed class GetAllProductsQuery : IRequest<List<GetAllProductsQueryResult>>;
