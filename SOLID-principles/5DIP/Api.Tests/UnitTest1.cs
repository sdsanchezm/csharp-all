using DependencyInversionPrinciple3.Controllers;
using DependencyInversionPrinciple3.Models;
using DependencyInversionPrinciple3.Repository;
using Xunit;
using Moq;
//global using Xunit;

namespace DependencyInversionPrinciple3.Api.Tests
{
    public class UserTest
    {
        //[Fact]
        //public void GetUser()
        //{
        //    var userController = new UserController();

        //    var resultGetUsers = userController.Get();

        //    Assert.NotNull(resultGetUsers);
        //    Assert.Equal(3, resultGetUsers.Count());
        //}


        [Fact]
        public void GetUser()
        {
            var LogbookMock = new Mock<ILogbook>();
            var userRepositoryMock = new Mock<IUserRepo>();
            userRepositoryMock.Setup(p => p.GetAll())
                                            .Returns(new List<User>()
                                            {
                                            new User(1, "Jara", new List<double>() { 3, 4 }),
                                            new User(2, "Amparo", new List<double>() { 1, 2 }),
                                            new User(3, "Tiche Maria", new List<double>() { 3, 1 })
                                            });

            var userController = new UserController(userRepositoryMock.Object, LogbookMock.Object);

            var resultGetUsers = userController.Get();

            Assert.NotNull(resultGetUsers);
            Assert.Equal(3, resultGetUsers.Count());
        }
    }
}