namespace Ambev.DeveloperEvaluation.Application.Sales.Commands
{
    public class CreateSaleItemCommand
    {
        public CreateSaleItemCommand(Guid productId, string productName, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public CreateSaleItemCommand(Guid productId, string productName, int quantity, decimal unitPrice) : this(productId, productName, quantity)
        {
        }

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
