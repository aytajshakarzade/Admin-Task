using Admin_Task.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin_Task.Models
{
    public class Projects : BaseEntity
    {
        //[Required(ErrorMessage = "Image URL is required...")]
        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [Required(ErrorMessage = "Title is required...")]
        [
            StringLength(100, ErrorMessage = "Title must be maximum 100 characters..."),
            MinLength(5, ErrorMessage = "Title must be minimum 5 characters...")
        ]

        public string Title { get; set; }


        [Required(ErrorMessage = "Category is required...")]
        [
            StringLength(100, ErrorMessage = "Category must be maximum 100 characters..."),
            MinLength(5, ErrorMessage = "Category must be minimum 5 characters...")
        ]

        public string Category { get; set; }
    }
}
