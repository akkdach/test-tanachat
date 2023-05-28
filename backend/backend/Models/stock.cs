using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Stock : BaseModel
    {
       [Key]
       public int stockId { get; set; }
        [Required]
       public int productId { get; set; }
        [Required]
       public double qty { get; set; }
    }
}
