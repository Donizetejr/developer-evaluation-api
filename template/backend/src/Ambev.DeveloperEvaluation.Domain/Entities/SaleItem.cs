namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem
    {
        public Guid Id { get; private set; }
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal Total => (UnitPrice * Quantity) - Discount;

        public SaleItem() { }

        public SaleItem(string productId, string productName, int quantity, decimal unitPrice)
        {
            if (quantity > 20)
                throw new DomainException("It is not allowed to sell more than 20 items of the same product.");

            Id = Guid.NewGuid();
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = CalculateDiscount(quantity, unitPrice);
        }

        public SaleItem(int quantity, decimal unitPrice)
        {
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        private decimal CalculateDiscount(int quantity, decimal unitPrice)
        {
            if (quantity >= 10 && quantity <= 20)
                return quantity * unitPrice * 0.2m;
            else if (quantity >= 4)
                return quantity * unitPrice * 0.1m;
            return 0;
        }
    }
}