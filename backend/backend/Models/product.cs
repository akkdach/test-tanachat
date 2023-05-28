using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Product : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId {get;set;}
        [Required]
        [MaxLength(50)]
        public string productName { get;set;}
        [Required]
        [MaxLength(255)]
        public string productDescription { get;set;}
        [Required]
        public double unitPrice { get;set;}
        [Required]
        [MaxLength(10)]
        public string unit { get;set;}

    }
}
