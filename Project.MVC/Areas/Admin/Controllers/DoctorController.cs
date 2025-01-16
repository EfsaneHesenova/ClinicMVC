using Microsoft.AspNetCore.Mvc;

namespace Project.MVC.Areas.Admin.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
