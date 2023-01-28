using Bilet_6.Models;
using Bilet_6.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bilet_6.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> _userManager { get; }
        SignInManager<AppUser> _signInManager { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM userVM)
        {
            if (!ModelState.IsValid) return View();
            var user = await _userManager.FindByNameAsync(userVM.UsernameorEmail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(userVM.UsernameorEmail);
                if (user == null)
                {
                    ModelState.AddModelError("", "username or password invalid");
                    return View();
                }
            }
            var result = await _signInManager.PasswordSignInAsync(user, userVM.Password, userVM.IsPersistance, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "username or password invalid");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
