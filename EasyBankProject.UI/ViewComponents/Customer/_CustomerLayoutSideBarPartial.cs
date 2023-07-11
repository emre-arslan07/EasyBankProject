using Microsoft.AspNetCore.Mvc;

namespace EasyBankProject.UI.ViewComponents.Customer
{
    public class _CustomerLayoutSideBarPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
