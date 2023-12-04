using System.ComponentModel.DataAnnotations;

namespace WebDemo14112023.Models
{
    public class Product
    {
        [Display(Name ="Mã sản phẩm")]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
