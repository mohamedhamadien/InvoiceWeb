namespace InvoiceWeb.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Store { get; set; }
        public List<Item> Items { get; set; }
        public decimal Total { get; set; }

        //public decimal Total => Items.Sum(x => x.Total);
    }
}
