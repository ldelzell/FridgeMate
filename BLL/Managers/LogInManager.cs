using BLL.Interfaces.Strategy_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class LogInManager
    {
        private ILogInStrategy _loginStrategy;

        public LogInManager(ILogInStrategy loginStrategy)
        {
            _loginStrategy = loginStrategy;
        }

        public bool Authenticate(string usernameOrPhoneNumber, string password, out int id)
        {
            return _loginStrategy.Authenticate(usernameOrPhoneNumber, password, out id);
        }
    }
}
