using System.ComponentModel.DataAnnotations;

namespace ProductService.Models
{
    public class Product
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
