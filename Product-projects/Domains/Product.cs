using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Product_projects.Domains
{
     [Table("Product")]
    public class Product
    {
        [Key]
        public Guid IdProduct { get; set; } = Guid.NewGuid();

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        
        public string? Name { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        
        public decimal Price { get; set; }
    }
}
