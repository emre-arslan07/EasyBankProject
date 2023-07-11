using Microsoft.AspNetCore.Mvc;

namespace EasyBankProject.UI.ViewComponents.Customer
{
    public class _CustomerLayoutNavBarPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
