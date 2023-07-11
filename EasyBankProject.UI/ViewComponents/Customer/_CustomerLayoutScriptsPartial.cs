using Microsoft.AspNetCore.Mvc;

namespace EasyBankProject.UI.ViewComponents.Customer
{
    public class _CustomerLayoutScriptsPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
