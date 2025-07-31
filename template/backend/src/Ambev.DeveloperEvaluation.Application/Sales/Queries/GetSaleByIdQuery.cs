using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries
{
    public record GetSaleByIdQuery(Guid Id) : IRequest<Sale?>;
}
