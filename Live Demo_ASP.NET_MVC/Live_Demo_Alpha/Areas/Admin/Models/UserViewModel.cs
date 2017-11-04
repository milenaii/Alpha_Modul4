using Live_Demo_Alpha.Data.Models;
using Live_Demo_Alpha.Models;
using System;
using System.Linq.Expressions;

namespace Live_Demo_Alpha.Areas.Admin.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public bool IsAdmin { get; set; }

        public static Expression<Func<ApplicationUser, UserViewModel>> Create
        {
            get
            {
                return u => new UserViewModel()
                {
                    Id = u.Id,
                    Username = u.UserName
                };
            }
        }
    }
}