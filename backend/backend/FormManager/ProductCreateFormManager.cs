using System.ComponentModel.DataAnnotations;

namespace backend.FormManager
{
    public class ProductCreateFormManager
    {
        [Required]
        [MaxLength(50)]
        public string productName { get; set; }
        [Required]
        [MaxLength(255)]
        public string productDescription { get; set; }
        [Required]
        public double unitPrice { get; set; }
        [Required]
        [MaxLength(10)]
        public string unit { get; set; }
        public double qty { get; set; }
    }
}
