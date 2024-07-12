using LiveCallMessageDotnetCore.Data.Entity;
using LIveCallMessagingDotnetCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LIveCallMessagingDotnetCore.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly MyDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, MyDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = string.IsNullOrEmpty(returnUrl) ? " " : returnUrl ;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto signIn, string returnUrl = "")
        {
            if (!ModelState.IsValid)
            {
                return View(signIn);
            }
            var data = await _dbContext.Users.FirstOrDefaultAsync(x=>x.Email == signIn.UsernameOrEmail);
            AppUser user = await _userManager.FindByEmailAsync(signIn.UsernameOrEmail) ?? await _userManager.FindByNameAsync(signIn.UsernameOrEmail) ?? await _userManager.FindByIdAsync(data.Id.ToString());

            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return View(signIn);
            }

            var result = await _signInManager.PasswordSignInAsync(user, signIn.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Invalid login attempt");
                return View(signIn);
            }

            if (!string.IsNullOrEmpty(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterDto register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            AppUser newUser = new AppUser
            {
                UserName = register.Username,
                Email = register.Email,
                CometUID = Guid.NewGuid(),
                Name = register.Name
            };

            var result = await _userManager.CreateAsync(newUser, register.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(register);
            }

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }
    }
}
