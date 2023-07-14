using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Web.Controllers
{
    public class PublisherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
