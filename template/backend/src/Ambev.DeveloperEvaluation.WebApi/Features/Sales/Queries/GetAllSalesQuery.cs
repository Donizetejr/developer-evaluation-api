using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Queries
{
    public record GetAllSalesQuery : IRequest<IEnumerable<Sale>>;
}
