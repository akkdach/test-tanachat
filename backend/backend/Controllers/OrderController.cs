using backend.DataManager;
using backend.FormManager;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design.Serialization;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private AppDbContext _db;
        public OrderController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateProeuct(List<OrderFormManager> input) {
            _db.Database.BeginTransaction();
            try {
                ///บันทกรายการสั่งซื้อสินค้า
                var orderDataManager = new OrderDataManager();
                var orderList = orderDataManager.CreateList(input);
                _db.orders.AddRange(orderList);
                // อัปเดทยอดคงเหลือ
                var stockList = new List<Stock>();
                foreach (var item in orderList)
                {
                    var stock = _db.stocks.FirstOrDefault(a => a.productId == item.productId);
                    if (stock != null)
                    {
                        stock.qty -= item.qty;
                        stockList.Add(stock);
                    }
                        
                }
                _db.stocks.UpdateRange(stockList);
                _db.SaveChanges();
                _db.Database.CommitTransaction();
            return new JsonResult(new { IsSuccess = true, StatusCode = 200, Message = "บันทึกสำเร็จ", DataResult = "" });
            }
            catch (Exception ex)
            {
                _db.Database.RollbackTransaction();
                Response.StatusCode = 500;
                return new JsonResult(new { IsSuccess = false, StatusCode = 500, Message = ex.Message, DataResult = "" });
            }
        }
    }
}