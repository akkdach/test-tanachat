using backend.DataManager;
using backend.FormManager;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design.Serialization;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private AppDbContext _db;
        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("get")]
        public IActionResult GetProduct()
        {

            try
            {
                var product = (from pd in _db.products
                               join st in _db.stocks on pd.productId equals st.productId
                               select new  {
                                   productId = pd.productId,
                                   productName = pd.productName,
                                   productDescription = pd.productDescription,
                                   unitPrice = pd.unitPrice,
                                   stockId = st.stockId,
                                   balance = st.qty
                               });

                return new JsonResult(new { IsSuccess = true, StatusCode = 200, Message = "Success", DataResult = product });
            }
            catch (Exception ex)
            {
                Response.StatusCode= 500;
                return new JsonResult(new { IsSuccess = false, StatusCode = 500, Message = ex.Message, DataResult = "" });
            }
            
        }

        [HttpGet]
        [Route("getById/{productId}")]
        public IActionResult GetProductById(int productId)
        {

            try
            {
                var product = (from pd in _db.products
                               join stock in _db.stocks on pd.productId equals stock.productId into stTemp
                               from st in stTemp.DefaultIfEmpty()
                               where pd.productId == productId
                               select new
                               {
                                   productId = pd.productId,
                                   productName = pd.productName,
                                   productDescription = pd.productDescription,
                                   unitPrice = pd.unitPrice,
                                   stockId = st.stockId,
                                   balance = st.qty
                               }).FirstOrDefault();

                return new JsonResult(new { IsSuccess = true, StatusCode = 200, Message = "Success", DataResult = product });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return new JsonResult(new { IsSuccess = false, StatusCode = 500, Message = ex.Message, DataResult = "" });
            }

        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateProeuct(ProductCreateFormManager input) {
            _db.Database.BeginTransaction();
            try {
                ///เพิ่มสินค้า
                var newProduct = new ProductDataManager(input);
                _db.products.Add(newProduct);
                _db.SaveChanges();
                // สร้างรายการสต๊อกสินค้า
                var newStock = new StockDataManager(input,newProduct.productId);
                _db.stocks.Add(newStock);
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