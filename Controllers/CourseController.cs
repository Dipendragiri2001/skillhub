using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillHub.Models;
using SkillHub.Repository;


namespace SkillHub.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly ICourseRepository _icourserepo;

        public CourseController(ICourseRepository icourserepo, UserManager<ApplicationUser> usermanager)
        {
            _icourserepo = icourserepo;
            _usermanager = usermanager;
        }
        public IActionResult Index()
        {
            var courses = _icourserepo.GetAll();
            var data = courses.Take(3);
            // var prds = _icourserepo.GetBy(x=>x.ProductName == "abc" && x.Id == 1);

            return View(data);
        }

        public IActionResult CourseDetail(int id)
        {
            var s = _icourserepo.GetSingle(x => x.Id == id);
            return View(s);
        }
        public IActionResult Edit(int id)
        {
            var product = _icourserepo.GetSingle(x => x.Id == id);
            return View(product);
        }

        public async Task<IActionResult> Create(Course c, string description2)
        {
            var files = HttpContext.Request.Form.Files;
            foreach (var Image in files)
            {
                var file = Image;
                var uploads = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/courseimage");
                var fileName = ContentDispositionHeaderValue.Parse
                                           (file.ContentDisposition).FileName.Trim('"');

                System.Console.WriteLine(fileName);
                using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                    c.ImageUrl = file.FileName;
                }
            }
            c.AboutCourse = description2;
            _icourserepo.Create(c);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult New()
        {
            ViewBag.username = _usermanager.GetUserName(HttpContext.User);
            return View();
        }
        public IActionResult Delete(int id)
        {
            _icourserepo.Delete(x => x.Id == id);
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public IActionResult Update(Course c)
        {
            _icourserepo.Update(c);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult AllCourses()
        {
           return View(_icourserepo.GetAll());

        }
    }
}
