using Microsoft.AspNetCore.Mvc;

namespace EasyBankProject.UI.Controllers
{
    public class CustomerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
