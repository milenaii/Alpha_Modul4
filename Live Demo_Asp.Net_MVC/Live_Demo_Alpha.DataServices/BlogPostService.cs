using Live_Demo_Alpha.Data;
using Live_Demo_Alpha.Data.DataModels;
using Live_Demo_Alpha.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Live_Demo_Alpha.DataServices
{
    public class BlogPostService : IBlogPostService
    {
        private readonly ApplicationDbContext dbContext;

        public BlogPostService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddBlogPost(string username, string title, string content)
        {
            ApplicationUser user = this.GetUser(username);

            BlogPost blogPost = new BlogPost()
            {
                Title = title,
                Content = content,
                ApplicationUserId = user.Id
            };

            this.dbContext.BlogPosts.Add(blogPost);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<BlogPostModel> GetTopPosts(int count)
        {
            return this.dbContext
                .BlogPosts
                .Select(b =>
                new BlogPostModel()
                {
                    Title = b.Title,
                    Content = b.Content,
                    Author = b.ApplicationUser.UserName
                })
                .Take(count)
                .ToList();
        }

        public IEnumerable<BlogPostModel> GetAllBlogPostsForUser(string username)
        {
            ApplicationUser user = this.GetUser(username);

            return this.dbContext
                .BlogPosts
                .Where(b => b.ApplicationUserId == user.Id)
                .Select(b => new BlogPostModel()
                {
                    Title = b.Title,
                    Content = b.Content
                })
                .ToList();
        }

        private ApplicationUser GetUser(string username)
        {
            var user = this.dbContext.Users.First(u => u.UserName == username);
            if (user == null)
            {
                throw new ArgumentException($"No user with username {username}!");
            }

            return user;
        }
    }
}