using Microsoft.AspNetCore.Identity;
using DietSystem.Models;
using DietSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DietSystem.Data;

namespace DietSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userMaganer;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _userMaganer = userManager;
            _signInManager = signInManager; 
            _context = context; 
        }
        [HttpGet]
        public IActionResult Login()
        {
            var response = new LoginVM();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM) 
        {
            if(!ModelState.IsValid)
            {
                return View(loginVM);
            }
            var user = await _userMaganer.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null) 
            {
                // User is found, check password
                var passwordCheck = await _userMaganer.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    // Password corrrcet, sigh in
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                // Password is incorrect 
                TempData["Error"] = "Дані неправильні. Спробуйте ще раз";
                return View(loginVM);     
            }
            // User not found
            TempData["Error"] = "Дані неправильні. Спробуйте ще раз";
            return View(loginVM);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var response = new RegisterVM();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if(!ModelState.IsValid)
            {
                return View(registerVM);
            }
            var user = await _userMaganer.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "Ця пошта вже використовується";
                return View(registerVM);
            }
            var newUser = new AppUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress,
            };
            var newUserResponse = await _userMaganer.CreateAsync(newUser,registerVM.Password);
            if(newUserResponse.Succeeded)
            {
                await _userMaganer.AddToRoleAsync(newUser, UserRoles.User);
            }
            return RedirectToAction("Index", "Ration");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
