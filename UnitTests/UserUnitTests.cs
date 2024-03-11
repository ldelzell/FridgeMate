using BLL.Interfaces;
using BLL.Managers;
using BLL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class UserUnitTests
    {
        [TestMethod]
        public void CreateUserWithCorrectData()
        {
            var mockRepository = new Mock<IUserDataAccess>();
            var userManager = new UserManager(mockRepository.Object);

            User user = new(
                0,
                "Stas",
                "Nikolov",
                58475,
                "stasnikolov03@gmail.com",
                "stas",
                "stas",
                "jhdjksmds.jpg"
                )
                ;
            userManager.Create(user);
            mockRepository.Verify(repo => repo.Create(user), Times.Once);
        }
        [TestMethod]
        public void CheckLogInWithCorrectData()
        {
            var mockRepository = new Mock<IUserDataAccess>();
            var userManager = new UserManager(mockRepository.Object);

            string username = "testuser";
            string password = "testpassword";
            int userId = 123; 

            mockRepository.Setup(repo => repo.CheckLogIn(username, password, out userId))
                          .Returns(true);

            bool result = userManager.CheckLogIn(username, password, out int returnedUserId);

            mockRepository.Verify(repo => repo.CheckLogIn(username, password, out userId), Times.Once);

            Assert.IsTrue(result);
            Assert.AreEqual(userId, returnedUserId);
        }
        [TestMethod]
        public void CheckLogInWithIncorrectData()
        {
            var mockRepository = new Mock<IUserDataAccess>();
            var userManager = new UserManager(mockRepository.Object);

            string username = "testuser";
            string password = "testpassword";
            int userId = 0; 

            mockRepository.Setup(repo => repo.CheckLogIn(username, password, out userId))
                          .Returns(false);

            bool result = userManager.CheckLogIn(username, password, out int returnedUserId);

            mockRepository.Verify(repo => repo.CheckLogIn(username, password, out userId), Times.Once);

            Assert.IsFalse(result);
            Assert.AreEqual(userId, returnedUserId);
        }
        [TestMethod]
        public void GetUserById_WhenUserExists()
        {
            var mockRepository = new Mock<IUserDataAccess>();
            var userManager = new UserManager(mockRepository.Object);

            int userId = 1;
            var expectedUser = new User(
                1,
                "Stas",
                "Nikolov",
                58475,
                "stasnikolov03@gmail.com",
                "stas",
                "stas",
                "jhdjksmds.jpg"
                )
                ;

            mockRepository.Setup(repo => repo.GetUserById(userId))
                          .Returns(expectedUser);

            User result = userManager.GetUserById(userId);

            mockRepository.Verify(repo => repo.GetUserById(userId), Times.Once);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser.Id, result.Id);
        }

        [TestMethod]
        public void GetUserById_WhenUserDoesNotExist()
        {
            var mockRepository = new Mock<IUserDataAccess>();
            var userManager = new UserManager(mockRepository.Object);

            int userId = 456; 

            mockRepository.Setup(repo => repo.GetUserById(userId))
                          .Returns((User)null);

            User result = userManager.GetUserById(userId);

            mockRepository.Verify(repo => repo.GetUserById(userId), Times.Once);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void GetAllUsers_WhenUsersExist()
        {
            var mockRepository = new Mock<IUserDataAccess>();
            var userManager = new UserManager(mockRepository.Object);

            var expectedUsers = new List<User>
            {
            new User(
                1,
                "Stas",
                "Nikolov",
                58475,
                "stasnikolov03@gmail.com",
                "stas",
                "stas",
                "jhdjksmds.jpg"
                )
            {
            },
            new User (
                1,
                "Alex",
                "Popov",
                584444,
                "alex@gmail.com",
                "alex",
                "alex",
                "jhdjksmds.jpg"
                )
            {
            }
        };
            mockRepository.Setup(repo => repo.GetAllUsers())
                          .Returns(expectedUsers);

            List<User> result = userManager.GetAllUsers();

            mockRepository.Verify(repo => repo.GetAllUsers(), Times.Once);

            CollectionAssert.AreEqual(expectedUsers, result);
        }
        [TestMethod]
        public void UpdateUserInfoSuccess()
        {
            var mockRepository = new Mock<IUserDataAccess>();
            var userManager = new UserManager(mockRepository.Object);

            User userToUpdate = new User(
                0,
                "Update",
                "Update",
                58475,
                "stasnikolov03@gmail.com",
                "stas",
                "stas",
                "jhdjksmds.jpg"
                )
                ;

            mockRepository.Setup(repo => repo.UpdateUserInfo(userToUpdate))
                          .Returns(true);

            bool result = userManager.UpdateUserInfo(userToUpdate);

            mockRepository.Verify(repo => repo.UpdateUserInfo(userToUpdate), Times.Once);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UsernameInExistance_WhenUsernameExists()
        {
            var mockRepository = new Mock<IUserDataAccess>();
            var userManager = new UserManager(mockRepository.Object);

            string existingUsername = "existingUser";

            mockRepository.Setup(repo => repo.UsernameInExistance(existingUsername))
                          .Returns(true);

            bool result = userManager.UsernameInExistance(existingUsername);

            mockRepository.Verify(repo => repo.UsernameInExistance(existingUsername), Times.Once);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UsernameInExistance_WhenUsernameDoesNotExist()
        {
            var mockRepository = new Mock<IUserDataAccess>();
            var userManager = new UserManager(mockRepository.Object);

            string nonExistingUsername = "nonExistingUser";

            mockRepository.Setup(repo => repo.UsernameInExistance(nonExistingUsername))
                          .Returns(false);

            bool result = userManager.UsernameInExistance(nonExistingUsername);

            mockRepository.Verify(repo => repo.UsernameInExistance(nonExistingUsername), Times.Once);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void GetUserImageByUserId_WhenUserExists()
        {
            var mockRepository = new Mock<IUserDataAccess>();
            var userManager = new UserManager(mockRepository.Object);

            int userId = 1; 
            string expectedUserImage = "userImage.jpg";

            mockRepository.Setup(repo => repo.GetUserImageByUserId(userId))
                          .Returns(expectedUserImage);

            string result = userManager.GetUserImageByUserId(userId);

            mockRepository.Verify(repo => repo.GetUserImageByUserId(userId), Times.Once);

            Assert.AreEqual(expectedUserImage, result);
        }

        [TestMethod]
        public void GetUserImageByUserId_WhenUserDoesNotExist()
        {
            var mockRepository = new Mock<IUserDataAccess>();
            var userManager = new UserManager(mockRepository.Object);

            int nonExistingUserId = 9992; 

            mockRepository.Setup(repo => repo.GetUserImageByUserId(nonExistingUserId))
                          .Returns((string)null);

            string result = userManager.GetUserImageByUserId(nonExistingUserId);

            mockRepository.Verify(repo => repo.GetUserImageByUserId(nonExistingUserId), Times.Once);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void UpdateUserInfoWithoutImage_WhenUserExists()
        {
            var mockRepository = new Mock<IUserDataAccess>();
            var userManager = new UserManager(mockRepository.Object);

            User userToUpdate = new User(
                 0,
                 "Update",
                 "Update",
                 58475,
                 "stasnikolov03@gmail.com",
                 "stas",
                 "stas",
                 "jhdjksmds.jpg"
                 )
                 ;

            mockRepository.Setup(repo => repo.UpdateUserInfoWithoutImage(userToUpdate))
                          .Returns(true);

            bool result = userManager.UpdateUserInfoWithoutImage(userToUpdate);

            mockRepository.Verify(repo => repo.UpdateUserInfoWithoutImage(userToUpdate), Times.Once);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateUserInfoWithoutImage_WhenUserDoesNotExist()
        {
            var mockRepository = new Mock<IUserDataAccess>();
            var userManager = new UserManager(mockRepository.Object);

            User nonExistingUser = new User(
                0,
                "Update",
                "Update",
                58475,
                "stasnikolov03@gmail.com",
                "stas",
                "stas",
                "jhdjksmds.jpg"
                )
                ;

            mockRepository.Setup(repo => repo.UpdateUserInfoWithoutImage(nonExistingUser))
                          .Returns(false);

            bool result = userManager.UpdateUserInfoWithoutImage(nonExistingUser);

            mockRepository.Verify(repo => repo.UpdateUserInfoWithoutImage(nonExistingUser), Times.Once);

            Assert.IsFalse(result);
        }
    }
}
