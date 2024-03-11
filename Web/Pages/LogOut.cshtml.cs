using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class LogOutModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            await HttpContext.SignOutAsync();
            Response.Cookies.Delete("userid_cookie");
            Response.Cookies.Delete("basket");
            HttpContext.Session.Clear();
            return RedirectToPage("LogIn");
        }
    }
}
