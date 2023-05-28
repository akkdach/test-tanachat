using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Order : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId { get; set; }
        [Required]
       public int orderDate { get; set; }
        [Required]
       public int productId { get; set; }  
        [Required]
       public double qty { get; set; }
    }
}
