using EasyBankProject.DTO.DTOs.AppUserDTOs;
using EasyBankProject.ENTITY.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace EasyBankProject.UI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDTO appUserRegisterDTO)
        {
            if (ModelState.IsValid)
            {
                Random random= new Random();
                int code;
                code = random.Next(100000, 1000000);

				AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDTO.Username,
                    Name = appUserRegisterDTO.Name,
                    Surname = appUserRegisterDTO.Surname,
                    Email = appUserRegisterDTO.Email,
                    City="aaaa",
                    District="bbbb",
                    ImageUrl="ccc",
                    ConfirmCode=code
                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDTO.Password);
                if (result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Bank Admin", "steamko944@gmail.com");
                    MailboxAddress mailboxAddressTo=new MailboxAddress("User",appUserRegisterDTO.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodybuilder = new BodyBuilder();
                    bodybuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz :" + code;
                    mimeMessage.Body = bodybuilder.ToMessageBody();
                    mimeMessage.Subject = "EasyBank Onay Kodu";

                    SmtpClient client=new SmtpClient();
                    client.Connect("smtp.gmail.com", 587, false);
					client.Authenticate("steamko944@gmail.com", "xhqtyhzesmunexmp");
					client.Send(mimeMessage);
					client.Disconnect(true);

                    TempData["Mail"] = appUserRegisterDTO.Email;
					return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
