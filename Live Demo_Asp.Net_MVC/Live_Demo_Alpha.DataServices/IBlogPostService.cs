using Live_Demo_Alpha.Data.DataModels;
using System.Collections.Generic;

namespace Live_Demo_Alpha.DataServices
{
    public interface IBlogPostService
    {
        IEnumerable<BlogPostModel> GetTopPosts(int count);

        IEnumerable<BlogPostModel> GetAllBlogPostsForUser(string username);

        void AddBlogPost(string username, string title, string content);
    }
}
