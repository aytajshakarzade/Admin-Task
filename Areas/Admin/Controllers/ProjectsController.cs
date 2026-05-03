using Admin_Task.DAL.Contexts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Admin_Task.Models;

namespace Admin_Task.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectsController : Controller
    {
        private readonly AppDbContext _db;
        public ProjectsController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Projects> projects = _db.Projects.ToList();
            return View(projects);
        }
    }
}
