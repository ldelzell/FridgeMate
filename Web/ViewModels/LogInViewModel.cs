
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Web.ViewModels
{
    public class LogInViewModel
    {

        [Required(ErrorMessage = "Username is Required!")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Password is Required!"), PasswordPropertyText]
        public string Password { get; set; }
        public LogInViewModel(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public LogInViewModel() { }
    }
}
