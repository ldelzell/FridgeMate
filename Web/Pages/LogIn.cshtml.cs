    using BLL.Managers;
using DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Web.ViewModels;

namespace Web.Pages
{
    public class LogInModel : PageModel
    {
        public UserManager userManager;
        [BindProperty]
        public LogInViewModel User { get; set; }
        
        public LogInModel()
        {
            userManager = new UserManager(new UserDataAccess());
        }
        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                bool isLogedIn = userManager.CheckLogIn(User.Username, User.Password, out int id);
                if (isLogedIn)
                {
                    List<Claim> claims = new List<Claim> {
                        new Claim(ClaimTypes.Name, User.Username),
                        new Claim("id", id.ToString())
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);

                    return RedirectToPage("Profile");
                }
                else {
                    return RedirectToPage("LogIn");
                }
            }
            return Page();
        }
    }
}
