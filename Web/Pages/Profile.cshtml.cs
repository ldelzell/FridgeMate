using BLL.Managers;
using BLL.Models;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.ViewModels;

namespace Web.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public UserViewModel UserModel { get; set; }
        public UserManager userManager;
        
        public Security security = new Security();
        //public string ImagePath { get; set; }


        private readonly ILogger<ProfileModel> _logger;
        public string HashedPassword { get; private set; } = string.Empty;

        public ProfileModel(ILogger<ProfileModel> logger)
        {
            UserModel = new();
            _logger = logger;
            userManager = new UserManager(new UserDataAccess());
        }
        public async Task<IActionResult> OnGet()
        {
            //imagePath = $"~Some Photos/Wallpapers - cars/1.jpg";
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("LogIn");
            }
            var userId = User.FindFirst("id");
            if (userId == null)
            {
                return RedirectToPage("LogIn");
            }
            else
            {
                int id = int.Parse(userId.Value);
                var user = userManager.GetUserById(id);
                if (user == null)
                {
                    string errorMessage = "Error";
                    ViewData["ErrorMessage"] = errorMessage;
                }
                else
                {
                    //ImagePath = userManager.GetUserImageByUserId(id);
                    
                    UserModel = new(
                        user.FirstName,
                        user.LastName,
                        user.PhoneNumber,
                        user.Email,
                        user.Username,
                        user.Password,
                        user.ImagePath
                    );
                    HashedPassword = security.HashPassword(user.Password, out var salt);
                }
                return Page();
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int id;
                    if (User.Identity.IsAuthenticated)
                    {
                        id = int.Parse(User.FindFirst("id").Value);
                    }
                    else
                    {
                        id = Convert.ToInt32(User.FindFirst("id"));
                    }
                    var userManager = new UserManager(new UserDataAccess());
                    User user1 = new User(
                        id,
                        UserModel.FirstName,
                        UserModel.LastName,
                        UserModel.PhoneNumber,
                        UserModel.Email,
                        UserModel.Username,
                        UserModel.Password,
                        UserModel.ImagePath
                        );
                    //if (string.IsNullOrEmpty(ImagePath))
                    //{
                    //    ImagePath = "/css/defaultImage";
                    //}
                    if (!userManager.UpdateUserInfoWithoutImage(user1))
                    {
                        string errorMessage = "error";
                        ViewData["ErrorMessage"] = errorMessage;
                    }
                    else
                    {
                        TempData["Message"] = "Profile updated successfully";
                        return RedirectToPage("/Profile");
                    }
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                }
            }
            return RedirectToPage("/Profile");
        }
    }
}
