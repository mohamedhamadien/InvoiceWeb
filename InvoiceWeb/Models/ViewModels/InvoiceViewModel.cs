namespace InvoiceWeb.Models.ViewModels
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Store { get; set; }
        public List<Item> Items { get; set; }
        //public decimal Total => Items.Sum(x => x.Total);

        public List<Store> Stores { get; set; }
        public List<Unit> Units { get; set; }
        public List<Invoice> Invoices { get; set; }

    }
}
