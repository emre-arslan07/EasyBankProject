using EasyBankProject.DTO.DTOs.AppUserDTOs;
using EasyBankProject.ENTITY.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyBankProject.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserLoginDTO appUserLoginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(appUserLoginDTO.Username, appUserLoginDTO.Password, false, true);
            if (result.Succeeded)
            {
                var user=await _userManager.FindByNameAsync(appUserLoginDTO.Username);
                if (user.EmailConfirmed==true)
                {
                return RedirectToAction("Index", "MyAccounts");
                }

            }
            return View();
        }
    }
}
