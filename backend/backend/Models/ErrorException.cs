namespace backend.Models
{
    public class ErrorException :Exception
    {
        public int Code { get; set; }
        public string Detail { get;set; }

        public ErrorException(int code, string detail)
        {
            this.Code = code;
            this.Detail = detail;
        }

    }
}
