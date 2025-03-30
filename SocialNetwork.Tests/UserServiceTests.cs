using Moq;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public void FindByEmail_UserExists_ReturnsUser()
        {
            // Arrange
            UserService userService = new UserService();
            UserRegistrationData registrationData = new UserRegistrationData()
            {
                Email = "test@gmail.com",
                FirstName = "TestFName",
                LastName = "TestLName",
                Password = "TestPwd000",
            };

            // Act
            userService.Register(registrationData);
            User user = userService.FindByEmail("test@gmail.com");

            // Assert (Проверка)
            Assert.NotNull(user); // Проверяем, что пользователь не null
            Assert.That(user.FirstName, Is.EqualTo("TestFName")); // Проверяем имя пользователя
            Assert.That(user.LastName, Is.EqualTo("TestLName")); // Проверяем фамилию пользователя
            Assert.That(user.Email, Is.EqualTo("test@gmail.com")); // Проверяем email

        }


        [Test]
        public void FindByEmail_UserDoesNotExist_ThrowsUserNotFoundException()
        {
            // Arrange 
            UserService userService = new UserService();
            UserRegistrationData registrationData = new UserRegistrationData()
            {
                Email = "test@gmail.com",
                FirstName = "TestFName1",
                LastName = "TestLName1",
                Password = "TestPwd000",
            };

            // Act
            userService.Register(registrationData);

            // Assert 
            Assert.Throws<UserNotFoundException>(() => userService.FindByEmail("nonexistent@gmail.com"));
        }
    }
}
