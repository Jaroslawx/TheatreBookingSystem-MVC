using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Models;
using TheatreBookingSystem_MVC.ViewModels;

namespace TheatreBookingSystem_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (user != null)
            {
                // User if found, check password
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (passwordCheck)
                {
                    // Password is correct, sign in
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                // Passowrd is incorrect
                TempData["Error"] = "Wrong credentials. Please, try again";
                return View(loginViewModel);
            }
            // User is not found
            TempData["Error"] = "Wrong credentials. Please, try again";
            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var user = await _userManager.FindByEmailAsync(registerViewModel.Email);
            if (user != null)
            {
                // User already exists
                TempData["Error"] = "This email is already in use";
                return View(registerViewModel);
            }

            var newUser = new AppUser
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email
            };
            var newUserResult = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (newUserResult.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return View("Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
