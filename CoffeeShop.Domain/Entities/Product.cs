
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Domain.Entities
{
    public class Product
    {

        public int ProductId { get; set; }

        //  [Required(ErrorMessage = "Podaj nazwę produktu")]
        public string Name { get; set; }

        // [Required]
        //  [Range(0.01, double.MaxValue, ErrorMessage = "Wprowadź prawidłową cenę")]
        public decimal Price { get; set; }


        public int Quantity { get; set; }

    }
}