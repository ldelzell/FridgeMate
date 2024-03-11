using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class UserManager
    {
        public IUserDataAccess data;

        public UserManager(IUserDataAccess data)
        {
            this.data = data;
        }
        public bool Create(User user) {
            return data.Create(user);
        }
        public bool CheckLogIn(string username, string password, out int id)
        {
            return data.CheckLogIn(username, password, out id);
        }
        public bool CheckLogInWithPhoneNumber(string phoneNumber, string password, out int id) 
        {
            return data.CheckLogInWithPhoneNumber(phoneNumber, password, out id);
        }
        public User? GetUserById(int id)
        {
            return data.GetUserById(id);
        }
        public List<User> GetAllUsers()
        {
            return data.GetAllUsers();
        }
        public bool UpdateUserInfo(User user)
        {
            return data.UpdateUserInfo(user);
        }
        public bool UpdateUserInfoWithoutImage(User user)
        {
            return data.UpdateUserInfoWithoutImage(user);
        }
        public string GetUserImageByUserId(int id) {
            return data.GetUserImageByUserId(id);
        }
        public bool UsernameInExistance(string username)
        {
             return data.UsernameInExistance(username);
        }
        
        public dynamic? GetSetting(string key)
        {
            return data.GetSetting(key);
        }
        public void SetSetting(string key, dynamic? value)
        {
            data.SetSetting(key, value);
        }
    }
}
