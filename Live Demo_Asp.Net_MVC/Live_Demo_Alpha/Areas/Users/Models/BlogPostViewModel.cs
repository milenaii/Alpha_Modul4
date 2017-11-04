using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Live_Demo_Alpha.Areas.Users.Models
{
    public class BlogPostViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Content is required")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Content should be between 10 and 1000")]
        public string Content { get; set; }
    }
}