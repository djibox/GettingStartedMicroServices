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
    }
}
