using Microsoft.AspNetCore.Mvc;

namespace MVC01.Controllers
{
    public class ProductController : Controller
    {
        //Action
        //GET --> BaseUrl/Product/Index
        [HttpGet] // Default
        public string Index()
        {
            return "Hello From Index";
        }
    }
}
