using System.ComponentModel.DataAnnotations;

namespace backend.FormManager
{
    public class OrderFormManager
    {
        [Required]
        public int productId { get; set; }
        [Required]
        public double qty { get; set; }
    }
}
