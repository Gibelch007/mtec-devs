using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MtecDevs.ViewModels;

namespace MtecDevs.Controllers;

    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<IdentityUser>_signInManager;
        private readonly UserManager<IdentityUser>_userManager;

    public static object MailAdress { get; private set; }

    public AccountController(
            ILogger<AccountController> logger,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager )
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            LoginVM loginVM = new(){
                UrlRetorno = returnUrl ?? Url.Content("~/")
            };
            return View(loginVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                //Verifico o Login

            }
            return View(login);
        }

        
        private static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress m = new(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
