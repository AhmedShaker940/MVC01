using Microsoft.AspNetCore.Mvc;

namespace MVC01.Controllers
{
    public class ProductController : Controller
    {
        //Action
        //GET --> BaseUrl/Product/TestAction
        [HttpGet] // Default
        public string TestAction()
        {
            return "Hello";
        }
    }
}
