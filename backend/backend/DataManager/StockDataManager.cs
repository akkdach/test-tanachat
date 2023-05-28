using backend.FormManager;
using backend.Models;

namespace backend.DataManager
{
    public class StockDataManager : Stock
    {
        public StockDataManager()
        {

        }


        /// <summary>
        /// สร้างโมเดลสำหรับ บันทึกคลังสินค้าใหม่และยอดคงเหลือ
        /// </summary>
        /// <param name="input"></param>
        /// <param name="id"></param>
        /// <exception cref="ErrorException"></exception>
        public StockDataManager(ProductCreateFormManager input,int  id)
        {
            try
            {
                qty= input.qty;
                productId = id;
                createBy = "Admin";
                createDate = DateTime.UtcNow;
            }
            catch (Exception)
            {
                throw new ErrorException(1001, "ข้อมูลสต๊อกสินค้าไม่ถูกต้อง");
            }
        }

    }
}
