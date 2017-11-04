using Live_Demo_Alpha.DataServices;
using Live_Demo_Alpha.Models;
using System.Linq;
using System.Web.Mvc;

namespace Live_Demo_Alpha.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogPostService blogPostService;

        public HomeController(IBlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult GetBlogPosts()
        {
            var viewModel = this.blogPostService.
                GetTopPosts(3)
                .Select(b =>
                new BlogPostViewModel()
                {
                    Title = b.Title,
                    Content = b.Content,
                    Author = b.Author
                })
                .ToList();

            return this.PartialView("_TopPosts", viewModel);
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}