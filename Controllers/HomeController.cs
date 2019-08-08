using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillHub.Models;
using SkillHub.Repository;

namespace SkillHub.Controllers
{
    public class HomeController : Controller
    {
         private readonly ICourseRepository _icourserepo;

        public HomeController(ICourseRepository icourserepo)
        {
            _icourserepo = icourserepo;
           
        }
        public IActionResult Index()
        {
           var s = _icourserepo.GetAll().OrderByDescending(x=>x.Id).Take(4);
           ViewBag.c =s ;
            return View(s);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
