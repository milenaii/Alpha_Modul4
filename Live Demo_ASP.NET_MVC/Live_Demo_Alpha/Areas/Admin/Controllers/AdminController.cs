using Live_Demo_Alpha.Areas.Admin.Models;
using Live_Demo_Alpha.Models;
using System.Linq;
using System.Web.Mvc;

namespace Live_Demo_Alpha.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationUserManager userManager;
        private readonly ApplicationDbContext dbContext;

        public AdminController(ApplicationUserManager userManager, ApplicationDbContext dbContext)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public ActionResult AllUsers()
        {
            var usersViewModel = this.dbContext
                .Users
                .Select(UserViewModel.Create).ToList();
            
            return this.View(usersViewModel);
        }
    }
}