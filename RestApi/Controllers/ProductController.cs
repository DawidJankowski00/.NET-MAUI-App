using Food.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var result = new List<Product>();

            return result;
        }
    }
}
