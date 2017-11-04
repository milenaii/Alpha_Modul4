using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Live_Demo_Alpha.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<BlogPost> blogPosts;

        public ApplicationUser()
        {
            this.blogPosts = new HashSet<BlogPost>();
        }

        [StringLength(100, MinimumLength = 5)]
        public string Description { get; set; }

        public virtual ICollection<BlogPost> BlogPosts
        {
            get
            {
                return this.blogPosts;
            }
            set
            {
                this.blogPosts = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}