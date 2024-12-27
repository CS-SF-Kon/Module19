using SocNet.BLL.Models;
using SocNet.BLL.Services;

namespace SocNet.Tests
{
    public class Tests
    {
        /// <summary>
        /// ���������� �� �������� ������ ����������� ����� �� ������������
        /// </summary>
        [Test]
        public void EmailValidatorCatchesWrongEmails()
        {
            UserService us = new UserService();

            var a = new UserRegistrationData()
            {
                FirstName = "Vanya",
                LastName = "Ivanov",
                Email = "abc123", // �������� �����
                Password = "123456789"
            };
            
            Assert.Throws<ArgumentNullException>(() => us.Register(a)); // ������� ������������������ � ����� ������ ������ ����� ������� ������ (������� ����� ���������� � RegistrationView)
        }
    }
}