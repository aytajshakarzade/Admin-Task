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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Projects projects)
        {
            _db.Projects.Add(projects);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        #region Hard Delete
        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    Projects projects = _db.Projects.Find(id);
        //    _db.Projects.Remove(projects);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
        #endregion

        // Soft Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Projects projects = _db.Projects.Find(id);
            projects.IsDeleted = true;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Restore
        [HttpPost]
        public IActionResult Restore(int id)
        {
            Projects projects = _db.Projects.Find(id);
            projects.IsDeleted = false;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
