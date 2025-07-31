using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Queries
{
    public record GetSaleByIdQuery(Guid Id) : IRequest<Sale?>;
}
