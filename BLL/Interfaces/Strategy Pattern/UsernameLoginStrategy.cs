using BLL.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Strategy_Pattern
{
    public class UsernameLoginStrategy : ILogInStrategy
    {
        public UserManager userManager;

        public UsernameLoginStrategy(UserManager userManager)
        {
            this.userManager = userManager;
        }

        public bool Authenticate(string username, string password, out int id)
        {
            return userManager.CheckLogIn(username, password, out id);
        }
    }
}
