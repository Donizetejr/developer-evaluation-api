using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands
{
    public class CreateSaleCommand : IRequest<Guid>
    {
        public string SaleNumber { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Guid BranchId { get; set; }
        public string BranchName { get; set; }
        public List<CreateSaleItemCommand> Items { get; set; }

        public CreateSaleCommand() { }

        public CreateSaleCommand(
            string saleNumber,
            DateTime date,
            Guid customerId,
            string customerName,
            Guid branchId,
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