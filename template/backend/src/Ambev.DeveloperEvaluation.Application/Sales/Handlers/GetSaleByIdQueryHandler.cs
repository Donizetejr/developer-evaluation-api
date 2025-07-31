using Ambev.DeveloperEvaluation.Application.Sales.Queries;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Handlers
{
    public class GetSaleByIdQueryHandler : IRequestHandler<GetSaleByIdQuery, Sale?>
    {
        private readonly ISaleRepository _repo;

        public GetSaleByIdQueryHandler(ISaleRepository repo)
        {
            _repo = repo;
        }

        public async Task<Sale?> Handle(GetSaleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByIdAsync(request.Id);
        }
    }
}
