using Microsoft.AspNetCore.Mvc;

namespace Project.MVC.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
