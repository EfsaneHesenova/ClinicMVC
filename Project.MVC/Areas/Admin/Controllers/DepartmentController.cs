using Microsoft.AspNetCore.Mvc;
using Project.BL.Services.Abstractions;
using Project.Core.Models;

namespace Project.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ICollection<Department> departments = await _departmentService.GetAllDepartmentAsync();
                return View(departments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
