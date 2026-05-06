using Admin_Task.DAL.Contexts;
using Admin_Task.Models;
using Admin_Task.Utilities.Image;
using Elfie.Serialization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Admin_Task.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectsController : Controller
    {
        private readonly AppDbContext _db;
        public readonly IWebHostEnvironment _env;
        public ProjectsController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
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
            if (!(projects.ImageFile.ContentType.Contains("image/")))
            {
                ModelState.AddModelError("ImageFile", "Please select an image file.");
                return View();
            }

            if (!(projects.ImageFile.Length > 2 * 1024 * 1024))
            {
                ModelState.AddModelError("ImageFile", "The image file size should not exceed 2MB.");
                return View();
            }

            
            projects.ImageUrl = projects.ImageFile.SaveImage(_env, "uploads/projects");
            if (!ModelState.IsValid) return View();
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

        //Update
        public IActionResult Update(int id)
        {
            Projects projects = _db.Projects.Find(id);
            return View(projects);
        }

        [HttpPost]
        public IActionResult Update(Projects projects)
        {
            if (!ModelState.IsValid) return View(projects);
            Projects oldprojects = _db.Projects.Find(projects.Id);
            oldprojects.Title = projects.Title;
            oldprojects.Category = projects.Category;
            oldprojects.ImageUrl = projects.ImageUrl;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
