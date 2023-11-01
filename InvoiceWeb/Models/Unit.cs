using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceWeb.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public decimal Price { get; set; }

        public int ItemId { get; set; }
    }
}