using Live_Demo_Alpha.Data.Models;

namespace Live_Demo_Alpha.Data.DataModels
{
    public class BlogPostModel
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string Author { get; set; }
    }
}
