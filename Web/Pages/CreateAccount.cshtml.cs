using BLL.Managers;
using BLL.Models;
using DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.IO;

namespace Web.Pages
{
    public class CreateAccountModel : PageModel
    {
        public UserManager userManager;


        [BindProperty]
        public RegisterViewModel RegisterUser { get; set; }
        public CreateAccountModel()
        {
            userManager = new UserManager(new UserDataAccess());
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            //if (ModelState.IsValid)
            //{
            //    User user = new(0, RegisterUser.FirstName, RegisterUser.LastName, RegisterUser.PhoneNumber, RegisterUser.Email, RegisterUser.Username, RegisterUser.Password, "0");

            //    if (userManager.Create(user))
            //    {
            //        return RedirectToPage("Profile");
            //    }
            //    else
            //    {
            //        string errorMessage = "There is no user";
            //        ViewData["ErrorMessage"] = errorMessage;
            //    }

            //}
            //return Page();

            if (ModelState.IsValid)
            {
                // Your existing code for creating the user

                // Validate ImagePath
                if (RegisterUser.Image.Length == 0)
                {
                    string errorMessage = "Image is required.";
                    ViewData["ErrorMessage"] = errorMessage;
                    return Page();
                }

                try
                {
                    byte[] bytes;
                    using (var memoryStream = new MemoryStream())
                    {
                        RegisterUser.Image.OpenReadStream().CopyTo(memoryStream);
                        bytes = memoryStream.ToArray();
                    }

                    using var content = new MultipartFormDataContent();
                    content.Add(new ByteArrayContent(bytes), "file", RegisterUser.Image.FileName);

                    using var client = new HttpClient();
                    HttpResponseMessage response = await client.PostAsync("http://localhost:5287/images", content);

                    if (!response.IsSuccessStatusCode)
                    {
                        string errorMessage = "Failed to upload image.";
                        ViewData["ErrorMessage"] = errorMessage;
                        return Page();
                    }

                    var imagePath = await response.Content.ReadAsStringAsync();
                    User user = new User(0, RegisterUser.FirstName, RegisterUser.LastName, RegisterUser.PhoneNumber, RegisterUser.Email, RegisterUser.Username, RegisterUser.Password, imagePath);
                    if (userManager.Create(user))
                    {
                        return RedirectToPage("Profile");
                    }
                    else
                    {
                        string errorMessage = "Failed to create user.";
                        ViewData["ErrorMessage"] = errorMessage;
                    }
                }
                catch (Exception ex)
                {
                    string errorMessage = $"Error occurred while uploading image: {ex.Message}";
                    ViewData["ErrorMessage"] = errorMessage;
                    return Page();
                }

            }

            return Page();

        }
    }
}
