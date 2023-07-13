using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.PresentationLayer.Controllers
{
    public class CustomerLayout : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
