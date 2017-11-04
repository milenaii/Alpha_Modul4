using System.Collections.Generic;

namespace Live_Demo_Alpha.Areas.Users.Models
{
    public class BlogPostContainerViewModel
    {
        public BlogPostViewModel CreateBlogPost { get; set; }

        public IEnumerable<BlogPostViewModel> BlogPosts { get; set; }
    }
}