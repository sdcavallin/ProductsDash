using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstWebAppMVC.Models
{
    public class ProductModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 100.00)]
        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [DisplayName("Description")]
        public string Description { get; set; }

    }
}
