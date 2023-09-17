using BLL;
using Common.Request;
using Common.Respond;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        NorthwindContext da = new NorthwindContext();
        private ProductSvc productSvc;
        public ProductController()
        {
            productSvc = new ProductSvc();
        }
        [HttpGet("get_all_product")]
        public IActionResult GetAllProduct()
        {
            var ds = da.Products.ToList();
            return Ok(ds);
        }
        [HttpGet("get_pruduct_by_id")]
        public IActionResult GetProductByID(int id)
        {
            var ds = da.Products.FirstOrDefault(s => s.ProductId == id);
            return Ok(ds);
        }
        [HttpPost("add_new_product")]
        public void Add([FromBody] Sanpham product)
        {
            Product p = new Product();
            p.ProductName = product.ProductName;
            p.UnitPrice = product.UnitPrice;         
            da.Products.Add(p);
            da.SaveChanges();
        }
        [HttpPut("edit")]
        public void Edit(int id, [FromBody] Sanpham product)
        {
            Product p = da.Products.FirstOrDefault(s => s.ProductId == id);
            p.ProductName = product.ProductName;
            p.UnitPrice = product.UnitPrice;
            da.Products.Update(p);
            da.SaveChanges();
        }
        [HttpDelete("delete")]
        public void Delete(int id)
        {
            Product p = da.Products.FirstOrDefault(s => s.ProductId == id);
            da.Products.Remove(p);
            da.SaveChanges();
        }
        [HttpPost("tim_nhieu_san_pham_co_phan_trang")]
        public IActionResult SearchProduct([FromBody] SearchProductReq searchProductReq)
        {
            var res = new SingleRsp();
            res = productSvc.SearchProduct(searchProductReq);
            return Ok(res);
        }
        [HttpPost("thong_ke_don_hang_theo_khach_hang")]
        public IActionResult ThongKeDonHangTheoKhachHang()
        {
            var ds = da.Orders.GroupBy(s => s.Customer.CompanyName).Select(g => new { g.Key, so_luong = g.Count() });
            var totalCus = ds.Count();
            var totalOrder = ds.ToList().Sum(s => s.so_luong);
            var res = new
            {
                Data = ds,
                tong_khach_hang = totalCus,
                tong_don_hang = totalOrder,
            };
            return Ok(res);
        }
        [HttpPost("thong_ke_doanh_thu_theo_nam")]
        public IActionResult ThongKeTheoNam(int year)
        {
            var ds = da.Orders.Where(s => s.OrderDate.Value.Year == year)
            .Join(da.OrderDetails, o => o.OrderId, d => d.OrderId, (o, d) => new { year = o.OrderDate.Value.Year, total = d.Quantity * d.UnitPrice })
            .GroupBy(g => g.year)
            .Select(s => new { s.Key, tong = s.Sum(s => s.total) });
            return Ok(ds);
        }
    }
}
