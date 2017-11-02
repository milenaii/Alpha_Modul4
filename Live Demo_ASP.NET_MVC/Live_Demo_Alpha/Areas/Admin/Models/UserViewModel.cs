using Live_Demo_Alpha.Models;
using System;
using System.Linq.Expressions;

namespace Live_Demo_Alpha.Areas.Admin.Models
{
    public class UserViewModel
    {
        public string Username { get; set; }

        public static Expression<Func<ApplicationUser, UserViewModel>> Create
        {
            get
            {
                return u => new UserViewModel()
                {
                    Username = u.UserName
                };
            }
        }
    }
}