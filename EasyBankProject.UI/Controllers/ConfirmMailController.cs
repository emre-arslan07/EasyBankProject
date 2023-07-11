using EasyBankProject.ENTITY.Concrete;
using EasyBankProject.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyBankProject.UI.Controllers
{
	public class ConfirmMailController : Controller
	{
        private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
		public IActionResult Index(int id)
		{
            var value = TempData["Mail"];
            ViewBag.Mail = value;
            return View();
		}

        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
        {
            var user = await _userManager.FindByEmailAsync(confirmMailViewModel.ConfirmMail);
            if (user.ConfirmCode==confirmMailViewModel.ConfirmCode) 
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}
