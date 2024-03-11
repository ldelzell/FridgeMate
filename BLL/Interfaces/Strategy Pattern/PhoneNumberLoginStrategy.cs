using BLL.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Strategy_Pattern
{
    public class PhoneNumberLoginStrategy : ILogInStrategy
    {
        public UserManager userManager;

        public PhoneNumberLoginStrategy(UserManager userManager)
        {
            this.userManager = userManager;
        }

        public bool Authenticate(string phoneNumber, string password, out int id)
        {
           
            return userManager.CheckLogInWithPhoneNumber(phoneNumber, password, out id);
        }
    }
}
