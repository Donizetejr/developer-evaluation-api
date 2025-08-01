namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; private set; }
        public string SaleNumber { get; private set; }
        public DateTime Date { get; private set; }
        public Guid CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public Guid BranchId { get; private set; }
        public string BranchName { get; private set; }
        public List<SaleItem> Items { get; private set; } = new();
        public bool IsCancelled { get; private set; }

        public decimal GetTotal() => Items.Sum(i => i.Total);

        private Sale() { }

        public Sale(
            string saleNumber,
            DateTime date,
            Guid customerId,
            string customerName,
            Guid branchId,
            string branchName,
            List<SaleItem> items)
        {
            Id = Guid.NewGuid();
            SaleNumber = saleNumber;
            Date = date;
            CustomerId = customerId;
            CustomerName = customerName;
            BranchId = branchId;
            BranchName = branchName;
            Items = items ?? new List<SaleItem>();
            IsCancelled = false;

            foreach (var item in Items)
                item.CalculateDiscount();
        }

        public void Cancel() => IsCancelled = true;
    }
}