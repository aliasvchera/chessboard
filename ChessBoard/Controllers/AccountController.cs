using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ChessBoard.Models;
using ChessBoard.Models.ViewModels;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

namespace ChessBoard.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [ValidateRecaptcha]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                User user = new User { UserName = model.Login, Language = model.Language };
                var result = await userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "player");
                    await signInManager.SignInAsync(user, false);
                    UserDataManipulation.NewGame(context, model.Login);
                    return RedirectToAction("Map", "Military");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        User user = await userManager.FindByNameAsync(model.Login);
                        var roles = await userManager.GetRolesAsync(user);
                        if (roles.Contains("admin"))
                        {
                            return RedirectToAction("TestMap", "Transition");
                        }
                        else
                        {
                            return RedirectToAction("Map", "Military"); // change on Main page
                        }                        
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Login or password is incorrect");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); // change on Main page
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
