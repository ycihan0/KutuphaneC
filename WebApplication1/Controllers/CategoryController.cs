using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Web.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
