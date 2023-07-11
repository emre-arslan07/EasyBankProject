using EasyBankProject.DTO.DTOs.AppUserDTOs;
using EasyBankProject.ENTITY.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyBankProject.UI.Controllers
{
    [Authorize]
    public class MyAccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditDTO appUserEditDTO= new AppUserEditDTO();
            appUserEditDTO.Name= values.Name;
            appUserEditDTO.Surname= values.Surname;
            appUserEditDTO.PhoneNumber= values.PhoneNumber;
            appUserEditDTO.Email= values.Email;
            appUserEditDTO.City= values.City;
            appUserEditDTO.District= values.District;
            appUserEditDTO.ImageUrl= values.ImageUrl;
            return View(appUserEditDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDTO appUserEditDTO)
        {
            if (appUserEditDTO.Password==appUserEditDTO.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = appUserEditDTO.Name;
                user.Surname = appUserEditDTO.Surname;
                user.PhoneNumber = appUserEditDTO.PhoneNumber;
                user.Email = appUserEditDTO.Email;
                user.City = appUserEditDTO.City;
                user.District = appUserEditDTO.District;
                user.ImageUrl = "test";
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDTO.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            
            return View();
        }
    }
}
