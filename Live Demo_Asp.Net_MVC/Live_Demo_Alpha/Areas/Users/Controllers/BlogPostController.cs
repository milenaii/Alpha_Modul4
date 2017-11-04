using Live_Demo_Alpha.DataServices;
using System.Web.Mvc;
using System.Linq;
using Live_Demo_Alpha.Areas.Users.Models;

namespace Live_Demo_Alpha.Areas.Users.Controllers
{
    [Authorize]
    public class BlogPostController : Controller
    {
        private readonly IBlogPostService blogPostService;

        public BlogPostController(IBlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
        }

        public ActionResult Index()
        {
            var blogPosts = this.blogPostService
                .GetAllBlogPostsForUser(this.User.Identity.Name)
                .Select(b => new BlogPostViewModel
                {
                    Title = b.Title,
                    Content = b.Content
                })
                .ToList();

            BlogPostContainerViewModel viewModel = new BlogPostContainerViewModel()
            {
                CreateBlogPost = new BlogPostViewModel(),
                BlogPosts = blogPosts
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(BlogPostContainerViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                this.blogPostService.AddBlogPost(this.User.Identity.Name, viewModel.CreateBlogPost.Title, viewModel.CreateBlogPost.Content);

                return this.RedirectToAction("Index");
            }

            return this.View(viewModel);
        }
    }
}