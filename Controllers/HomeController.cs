using Admin_Task.DAL.Contexts;
using Admin_Task.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Admin_Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            var vm = new HomeVM
            {
                Projects = _db.Projects
                    .Where(p => !p.IsDeleted)
                    .ToList()
            };

            return View(vm);
        }
    }
}