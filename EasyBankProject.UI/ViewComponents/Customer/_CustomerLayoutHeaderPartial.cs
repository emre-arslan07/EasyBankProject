﻿using Microsoft.AspNetCore.Mvc;

namespace EasyBankProject.UI.ViewComponents.Customer
{
    public class _CustomerLayoutHeaderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
