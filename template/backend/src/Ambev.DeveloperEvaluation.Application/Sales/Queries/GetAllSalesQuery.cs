using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries
{
    public record GetAllSalesQuery : IRequest<IEnumerable<Sale>>;
}
