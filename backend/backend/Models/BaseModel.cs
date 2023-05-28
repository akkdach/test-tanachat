namespace backend.Models
{
    public class BaseModel
    {
        public string createBy { get; set; } = "";
        public DateTime createDate { get; set; }
        public string updateBy { get; set; } = "";
        public DateTime updateDate { get; set; } = DateTime.UtcNow;
        public Boolean isActive { get; set; } = true;
    }
}
