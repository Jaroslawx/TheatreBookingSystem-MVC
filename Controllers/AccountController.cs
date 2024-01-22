using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TheatreBookingSystem_MVC.Configuration;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Models;
using TheatreBookingSystem_MVC.Services.Email;
using TheatreBookingSystem_MVC.ViewModels;

namespace TheatreBookingSystem_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private IOptions<SmtpSettings> _smtpSettings;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
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

        [HttpGet]
        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);
            if (user != null)
            {
                // User already exists
                TempData["Error"] = "This email is already in use";
                return View(registerViewModel);
            }

            var newUser = new AppUser()
            {
                Email = registerViewModel.EmailAddress,
                UserName = registerViewModel.EmailAddress
            };
            var newUserResult = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (newUserResult.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return RedirectToAction("Index", "Event");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Event");
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(forgotPasswordViewModel.Email);
                if (user == null)
                {
                    // User not found
                    TempData["Error"] = "User not found";
                    return View(forgotPasswordViewModel);
                }

                string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResetLink = Url.Action("ResetPassword", "Account", new { email = forgotPasswordViewModel.Email, token = token }, Request.Scheme);

                var emailSender = new EmailSender(_smtpSettings);
                await emailSender.SendEmailAsync(user.Email, "Password reset", $"Click <a href=\"{passwordResetLink}\">here</a> to reset your password");

                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }
            

            return View(forgotPasswordViewModel);
        }

        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult ResetPassword(string token)
        {
            return token == null ? View("Error") : View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid) return View(resetPasswordViewModel);

            var user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);
            if (user == null)
            {
                // User not found
                TempData["Error"] = "User not found";
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }

            var resetPasswordResult = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.Token, resetPasswordViewModel.Password);
            if (resetPasswordResult.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }

            return View();
        }

    }
}
