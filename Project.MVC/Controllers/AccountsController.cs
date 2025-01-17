using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs.AppUserDtos;
using Project.BL.Services.Abstractions;

namespace Project.MVC.Controllers
{
   
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(CreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createDto);
            }
            try
            {
                bool result = await _accountService.RegisterAsync(createDto);
                if (!result)
                {
                    return View(createDto);
                }
                return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDto);
            }
            try
            {
                bool result = await _accountService.LoginAsync(loginDto);
                if (result)
                {
                    return View(loginDto);
                }
                return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Logout()
        {
            try
            {
                await _accountService.LogoutAsync();
                return View(nameof(Index), "Home");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
