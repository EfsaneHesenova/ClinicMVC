using Microsoft.AspNetCore.Mvc;
using Project.BL.Services.Abstractions;
using Project.Core.Models;

namespace Project.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ICollection<Doctor> doctors = await _doctorService.GetAllDoctorAsync();
                return View(doctors);
            }
           catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
