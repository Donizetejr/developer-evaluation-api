namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal Total => (UnitPrice * Quantity) - Discount;

        // EF Core navigation
        public Guid SaleId { get; private set; }
        public Sale Sale { get; private set; }

        // Construtor para EF Core
        private SaleItem() { }

        public SaleItem(Guid productId, string productName, int quantity, decimal unitPrice)
        {
            if (quantity > 20)
                throw new DomainException("It is not allowed to sell more than 20 items of the same product.");

            Id = Guid.NewGuid();
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;

            CalculateDiscount();
        }

        public void CalculateDiscount()
        {
            if (Quantity >= 10 && Quantity <= 20)
                Discount = Quantity * UnitPrice * 0.20m;
            else if (Quantity >= 4)
                Discount = Quantity * UnitPrice * 0.10m;
            else
                Discount = 0;
        }
    }
}