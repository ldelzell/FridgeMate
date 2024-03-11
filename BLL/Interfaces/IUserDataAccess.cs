using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserDataAccess
    {
        bool Create(User user);
        bool CheckLogIn(string username, string password, out int id);
        bool CheckLogInWithPhoneNumber(string phoneNumber, string password, out int id);
        List<User> GetAllUsers();
        User GetUserById(int id);
        bool UpdateUserInfo(User user);
        string GetUserImageByUserId(int id);
        public bool UpdateUserInfoWithoutImage(User user);
        public bool UsernameInExistance(string username);
        void SetSetting(string key, dynamic? value);
        dynamic? GetSetting(string key);
    }
}
