namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; private set; }
        public string SaleNumber { get; private set; }
        public DateTime Date { get; private set; }
        public string CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public string BranchId { get; private set; }
        public string BranchName { get; private set; }
        public List<SaleItem> Items { get; private set; }
        public bool IsCancelled { get; private set; }

        public Sale()
        {
            Items = new List<SaleItem>();
        }

        public Sale(string saleNumber, DateTime date, string customerId, string customerName,
                    string branchId, string branchName, List<SaleItem> items)
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
        }

        public Sale(string saleNumber, DateTime date, string customerName, string branchId, string branchName, List<SaleItem> items)
        {
            SaleNumber = saleNumber;
            Date = date;
            CustomerName = customerName;
            BranchId = branchId;
            BranchName = branchName;
            Items = items;
        }

        public void Cancel()
        {
            IsCancelled = true;
        }

        public decimal GetTotal() => Items.Sum(i => i.Total);
    }
}