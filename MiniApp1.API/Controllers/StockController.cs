using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MiniApp1.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStock()
        {

            // veri tabanın istediğimiz kullanıcıya ait bilgileri alabilira
            var userName = HttpContext.User.Identity.Name;
          //token içerisinden Iyı alıyoruz
            var userIdClaim= User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            //  veri tabınında userıd yada username üzerinden stok bilgielrini eşleştirebilirz
            return Ok($" Stock Process Username:{userName}-UserId:{userIdClaim.Value}");


        }
    }
}
