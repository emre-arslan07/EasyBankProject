using EasyBankProject.BLL.Abstract;
using EasyBankProject.BLL.Concrete;
using EasyBankProject.DTO.DTOs.CustomerAccountProcessDTOs;
using EasyBankProject.ENTITY.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyBankProject.UI.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountService _customerAccountService;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountService customerAccountService, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountService = customerAccountService;
            _customerAccountProcessService= customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index(string mycurrency)
        {
            ViewBag.mycurrency = mycurrency;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDTO sendMoneyForCustomerAccountProcessDTO)
        {
            var user= await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberID = _customerAccountService.GetWhere(x => x.CustomerAccountNumber == sendMoneyForCustomerAccountProcessDTO.ReceiverAccountNumber).Select(y => y.CustomerAccountID).FirstOrDefault();

            var senderAccountNumberID = _customerAccountService.GetWhere(x => x.AppUserID == user.Id).Where(y => y.CustomerAccountCurrency == "Türk Lirası").Select(z => z.CustomerAccountID).FirstOrDefault();

           var result= await _customerAccountProcessService.AddAsync(new CustomerAccountProcess()
            {
                ProcessDate=Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                SenderID=senderAccountNumberID,
                ProcessType="Havale",
                ReceiverID=receiverAccountNumberID,
                Amount=sendMoneyForCustomerAccountProcessDTO.Amount,
                Description=sendMoneyForCustomerAccountProcessDTO.Description
            });

                
            

            //_customerAccountService.AddAsync();
            return RedirectToAction("Index", "Deneme");
        }
    }
}
