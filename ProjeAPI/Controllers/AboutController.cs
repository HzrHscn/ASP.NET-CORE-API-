using Microsoft.AspNetCore.Mvc;

namespace ProjeUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
