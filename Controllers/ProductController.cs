using Microsoft.AspNetCore.Mvc;

namespace MVC01.Controllers
{
    [Route("Prod")]
    public class ProductController : Controller
    {
        #region Actions
        //Action
        //GET --> BaseUrl/Product/Index
        [HttpGet] // Default

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = new List<Product>()
            {
                new(){Id = 1 ,Name ="Laptop" },
                new(){Id = 1 ,Name ="Iphone" },
            };
            return Json(products);
        }
        [HttpGet]
        public IActionResult GetProductsByID(int id)
        {
            if (id < 0)
                return BadRequest();
            else if (id == 0)
                return RedirectToAction(nameof(GetProducts));
            else if (id > 50)
                return Redirect("https://www.google.com");
            else
                return Json(new Product() { Id = id });

        }
        #endregion

        #region Routing

        [HttpGet]
        // BaseUrl/Product/JsonAction -- Convential Routing
        // BaseUrl/Prod/JsonAction -- Attribute Routing
        // BaseUrl/Product/Json -- Attribute Routing
        public IActionResult JsonAction()
        {
            return Json("Hello FromJson Action");
        }

        #endregion

        #region ModelBinding
        //BaseUrl/Product/Search?/Name=Iphone17&Color=Black
        //BaseUrl/Product/Search?/Name=Iphone17&Storage=512
        //BaseUrl/Product/Search?/Storage=512

        public IActionResult Search(ProductFilter filter)
        { 
            return View();
        }
        //Route
        //BaseUrl/Product/GetById/10         -> Id = 0 , otherId = 0
        //BaseUrl/Product/GetById?id=20        -> Id = 20 , otherId = 0
        //BaseUrl/Product/GetById?otherId=20        -> Id = 0 , otherId = 0
        //BaseUrl/Product/GetById?id2=20&id=50       -> Id = 50 , otherId = 20


        public IActionResult GetById([FromQuery]int id , [FromQuery (Name ="id2")] int otherId)
        {
            return Json("");
        }

        #endregion

    }
}
