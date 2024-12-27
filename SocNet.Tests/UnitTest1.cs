using SocNet.BLL.Models;
using SocNet.BLL.Services;

namespace SocNet.Tests
{
    public class Tests
    {
        /// <summary>
        /// ќтработает ли проверка адреса электронной почты на корректность
        /// </summary>
        [Test]
        public void EmailValidatorCatchesWrongEmails()
        {
            UserService us = new UserService();

            var a = new UserRegistrationData()
            {
                FirstName = "Vanya",
                LastName = "Ivanov",
                Email = "abc123", // кос€чна€ почта
                Password = "123456789"
            };
            
            Assert.Throws<ArgumentNullException>(() => us.Register(a)); // попытка зарегистрироватьс€ с такой почтой должна будет вызвать ошибку (котора€ будет обработана в RegistrationView)
        }
    }
}