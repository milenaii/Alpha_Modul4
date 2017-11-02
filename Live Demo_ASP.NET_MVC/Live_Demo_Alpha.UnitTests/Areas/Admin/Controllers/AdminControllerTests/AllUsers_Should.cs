using Live_Demo_Alpha.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Testing;
using System.Data.Entity;
using Live_Demo_Alpha.Areas.Admin.Controllers;
using Live_Demo_Alpha.Areas.Admin.Models;
using TestStack.FluentMVCTesting;
using Microsoft.AspNet.Identity;

namespace Live_Demo_Alpha.UnitTests.Areas.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class AllUsers_Should
    {
        [TestMethod]
        public void ReturnDefaultViewWithCorrectViewModel()
        {
            // Arrange
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);
            var dbContextMock = new Mock<ApplicationDbContext>();

            List<ApplicationUser> users = new List<ApplicationUser>()
            {
                new ApplicationUser() { UserName = "firstUser" },
                new ApplicationUser() { UserName = "secondUser" }
            };
            var usersSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(users);

            var resultViewModel = users.AsQueryable().Select(UserViewModel.Create).ToList();

            dbContextMock.SetupGet(m => m.Users).Returns(usersSetMock.Object);

            AdminController controller = new AdminController(userManagerMock.Object, dbContextMock.Object);

            // Act & Assert
            controller
                .WithCallTo(c => c.AllUsers())
                .ShouldRenderDefaultView()
                .WithModel<List<UserViewModel>>(viewModel =>
                {
                    for (int i = 0; i < viewModel.Count; i++)
                    {
                        Assert.AreEqual(resultViewModel[i].Username, viewModel[i].Username);
                    }
                });
        }
    }
}
