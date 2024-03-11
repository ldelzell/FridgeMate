using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? LastName { get; private set; }
        public string FirstName { get; private set; }
        public int PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string ImagePath { get; private set; }
        public User(int id, string firstName, string? lastName, int phoneNumber, string email, string username, string password, string imagePath)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Username = username;
            Password = password;
            ImagePath = imagePath;
        }
        public User(int id, string firstName, string? lastName, int phoneNumber, string email, string username, string password/*, byte[] image*/)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Username = username;
            Password = password;
            //Image = image;
        }
        public User(int id, string firstName, string? lastName, int phoneNumber, string email, string password/*, byte[] image*/)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            //Image = image;
        }
        public void Update(string firstName, string lastName, string username, int phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = username;
            this.PhoneNumber = phoneNumber;
        }
        public void UpdateImage(string imagePath)
        {
            this.ImagePath = imagePath;
        }
    }

}
