using System.ComponentModel.DataAnnotations;

namespace InvoiceWeb.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be 1 or more")]
        public int Quantity { get; set; }

        public decimal Total { get; set; }


        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100")]

        public decimal Discount { get; set; }

        public decimal Net { get; set; }


        [Required(ErrorMessage = "Unit is required")]
        public string Unit { get; set; }
    }
}