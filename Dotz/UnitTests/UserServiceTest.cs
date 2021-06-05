using Dotz.Domain.Entities;
using Dotz.Domain.Interfaces;
using Dotz.Domain.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void CreateUserShouldThrowExceptionAsync()
        {
            var repository = new Mock<IUserRepository>();
            repository.Setup(s => s.Find("user")).ReturnsAsync(new User());
            var tokenService = new Mock<ITokenService>();

            var service = new UserService(repository.Object, tokenService.Object);
            Func<Task> act = async () => { await service.CreateAsync("user", "password"); };

            act.Should().Throw<Exception>().WithMessage("E-mail já cadastrado");
        }

        [TestMethod]
        public void LoginShouldThrowExceptionAsync()
        {
            var repository = new Mock<IUserRepository>();
            repository.Setup(s => s.Find("user", GetHash("password"))).ReturnsAsync((User)null);
            var tokenService = new Mock<ITokenService>();

            var service = new UserService(repository.Object, tokenService.Object);
            Func<Task> act = async () => { await service.Login("user", "password"); };

            act.Should().Throw<Exception>().WithMessage("Senha incorreta ou usuário inexistente");
        }

        private string GetHash(string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return Encoding.ASCII.GetString(data);
        }
    }
}
