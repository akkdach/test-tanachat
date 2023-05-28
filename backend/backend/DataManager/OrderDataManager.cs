using backend.FormManager;
using backend.Models;

namespace backend.DataManager
{
    public class OrderDataManager : Order
    {
        public OrderDataManager()
        {

        }

        public List<Order> CreateList(List<OrderFormManager> input)
        {
            try
            {
                List<Order> orderList = new List<Order>();
                foreach (var item in input)
                {
                    var order = new Order();
                    order.qty = item.qty;
                    order.productId = item.productId;
                    order.createBy = "Admin";
                    order.createDate = DateTime.UtcNow;
                    
                    orderList.Add(order);
                }
                return orderList;
            }
            catch (Exception)
            {
                throw new ErrorException(1001, "ข้อมูลสต๊อกสินค้าไม่ถูกต้อง");
            }
        }

    }
}
