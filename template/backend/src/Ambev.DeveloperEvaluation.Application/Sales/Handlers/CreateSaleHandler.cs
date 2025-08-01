using Ambev.DeveloperEvaluation.Application.Sales.Commands;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.Handlers
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, Guid>
    {
        private readonly ISaleRepository _repository;
        private readonly ILogger<CreateSaleHandler> _logger;

        public CreateSaleHandler(ISaleRepository repository, ILogger<CreateSaleHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            if (request.Items == null || !request.Items.Any())
                throw new ArgumentException("The sale must contain at least one item.");

            var items = request.Items.Select(i => new SaleItem(
                i.ProductId,
                i.ProductName,
                i.Quantity,
                i.UnitPrice
            )).ToList();

            var sale = new Sale(
                request.SaleNumber,
                request.Date,
                request.CustomerId,
                request.CustomerName,
                request.BranchId,
                request.BranchName,
                items
            );

            await _repository.SaveAsync(sale);
            _logger.LogInformation($"✅ SaleCreated: {sale.Id}");

            return sale.Id;
        }
    }
}