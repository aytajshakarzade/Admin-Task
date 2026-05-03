using Admin_Task.Models.Base;

namespace Admin_Task.Models
{
    public class Projects:BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
    }
}
