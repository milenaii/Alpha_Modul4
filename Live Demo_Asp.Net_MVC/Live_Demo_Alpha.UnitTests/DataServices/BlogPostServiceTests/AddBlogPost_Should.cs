using Live_Demo_Alpha.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Testing;
using Live_Demo_Alpha.Data.Models;
using System.Data.Entity;
using Live_Demo_Alpha.DataServices;

namespace Live_Demo_Alpha.UnitTests.DataServices.BlogPostServiceTests
{
    [TestClass]
    public class AddBlogPost_Should
    {
        [TestMethod]
        public void AddBlogPostToContext_WhenParametersAreValid()
        {
            // Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            string userId = "userId";
            string username = "username";
            string title = "post title";
            string content = "post content";
            List<ApplicationUser> users = new List<ApplicationUser>()
            {
                new ApplicationUser() { UserName = username, Id = userId }
            };
            List<BlogPost> blogPosts = new List<BlogPost>();

            var usersSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(users);
            var blogPostsSetMock = new Mock<DbSet<BlogPost>>().SetupData(blogPosts);

            dbContextMock.SetupGet(m => m.Users).Returns(usersSetMock.Object);
            dbContextMock.SetupGet(m => m.BlogPosts).Returns(blogPostsSetMock.Object);

            BlogPostService service = new BlogPostService(dbContextMock.Object);

            // Act
            service.AddBlogPost(username, title, content);

            // Assert
            var blogPost = dbContextMock.Object.BlogPosts.Single();
            Assert.AreEqual(title, blogPost.Title);
            Assert.AreEqual(content, blogPost.Content);
            Assert.AreEqual(userId, blogPost.ApplicationUserId);

            dbContextMock.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
