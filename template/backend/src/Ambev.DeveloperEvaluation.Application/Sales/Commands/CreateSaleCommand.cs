using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands
{
    public class CreateSaleCommand : IRequest<Guid>
    {
        public string SaleNumber { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public List<CreateSaleItemCommand> Items { get; set; }

        public CreateSaleCommand(
            string saleNumber,
            DateTime date,
            Guid customerId,
            string customerName,
            string branchId,
            string branchName,
            List<CreateSaleItemCommand> items)
        {
            SaleNumber = saleNumber;
            Date = date;
            CustomerId = customerId;
            CustomerName = customerName;
            BranchId = branchId;
            BranchName = branchName;
            Items = items;
        }
    }
}
