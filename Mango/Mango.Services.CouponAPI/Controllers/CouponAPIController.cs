using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {

        private readonly AppDbContext _db;
        public CouponAPIController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]

        public object Get()
        {
            try
            {
                IEnumerable<Coupon> objectList = _db.Coupons.ToList();
                return objectList;

            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        [HttpGet]
        [Route("{id:int}")]
        public object Get(int id)
        {
            try
            {
                Coupon objectList = _db.Coupons.First(c=>c.CouponId==id);
                return objectList;

            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

    }
}
