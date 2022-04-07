using projectC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projectC.Data;
using projectC.Models;

namespace projectC.Controllers
{
    public class SubjectController : Controller
    {
        public readonly projectCContext _db;

        public SubjectController(projectCContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Subject> listofsubjects = _db.Subject;
            return View(listofsubjects);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create([Bind("Subject_Name,syllabus,credits")] Subject studobj)
        {

            _db.Subject.Add(studobj);
            _db.SaveChanges();
            return RedirectToAction("Index");


            return View(studobj);
        }


        [HttpGet]
        public IActionResult Edit(int subjectid)
        {
            var subobj = _db.Subject.Find(subjectid);
            return View(subobj);

        }

        [HttpPost]
        public IActionResult Edit(Subject updatedvaluesobj)
        {
            _db.Subject.Update(updatedvaluesobj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}