namespace Ambev.DeveloperEvaluation.Application.Sales.Commands
{
    public class CreateSaleItemCommand
    {
        public CreateSaleItemCommand() { }

        public CreateSaleItemCommand(Guid productId, string productName, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}