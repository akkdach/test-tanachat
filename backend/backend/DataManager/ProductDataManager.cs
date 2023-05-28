using backend.FormManager;
using backend.Models;

namespace backend.DataManager
{
    public class ProductDataManager : Product
    {
        public ProductDataManager()
        {

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="ErrorException"></exception>
        public ProductDataManager(ProductCreateFormManager input)
        {
            try
            {
                productName = input.productName;
                productDescription = input.productDescription;
                unitPrice = input.unitPrice;
                unit = input.unit;
                createBy = "Admin";
                createDate = DateTime.UtcNow;
            }
            catch (Exception)
            {
                throw new ErrorException(1001, "ข้อมูลสินค้าไม่ถูกต้อง");
            }
        }


    }
}
