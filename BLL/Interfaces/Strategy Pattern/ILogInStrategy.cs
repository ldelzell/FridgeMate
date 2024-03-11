using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Strategy_Pattern
{
    public interface ILogInStrategy
    {
        bool Authenticate(string username, string password, out int id);
    }
}
