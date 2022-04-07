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
    public class StudentController : Controller
    {
        public readonly projectCContext _db;

        public StudentController(projectCContext db)
        {
            _db = db;
        }
        private void PopulateSubjectsDropDownList(object selectedSubject = null)
        {
            var subjectsQuery = from s in _db.Subject
                                orderby s.Subject_Name
                                select new { SubjectId = s.ID, s.Subject_Name };

            ViewBag.SubjectID = new SelectList(subjectsQuery.AsNoTracking(), "SubjectId", "Subject_Name", selectedSubject);

        }

        public IActionResult Index()
        {

            IEnumerable<Student> objList = _db.Student;
            return View(objList);
        }

        //Get Create
        public IActionResult Create()
        {
            PopulateSubjectsDropDownList();
            return View();
        }


        [HttpPost]
        public IActionResult Create([Bind("Name,Class,SubjectId")] Student studobj)
        {
            
                _db.Student.Add(studobj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            

            return View(studobj);
        }

        //Get Create
        public IActionResult Edit(int id)
        {

            var studobj = _db.Student.Find(id);
            return View(studobj);
        }


        [HttpPost]
        public IActionResult Edit(Student obj)
        {
            
                _db.Student.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
            return View(obj);
        }

        //Get Delete
        public IActionResult Delete(int id)
        {

            var studobj = _db.Student.Find(id);
            return View(studobj);
        }


        [HttpPost]
        public IActionResult DeletePost(int studentid)
        {
            var studobj = _db.Student.Find(studentid);

            if (ModelState.IsValid)
            {

                _db.Student.Remove(studobj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studobj);
        }
    }
}