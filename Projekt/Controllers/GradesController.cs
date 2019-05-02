using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekt.DataAccessLayer;
using Projekt.Models;
using Projekt.ViewModels;

namespace Projekt.Controllers
{
    public class GradesController : Controller
    {

       private GradesContext db = new GradesContext();
       private StudentsContext sc = new StudentsContext();

        // GET: Grades
        public ActionResult Index(int id)
        {
            var grades = from grd in db.Grades
                where grd.StudentId == id
                select grd;
            var student = sc.Students.Find(id);

            var viewModel = new GradeIndexViewModel //zrobione
            {
                Grades =grades,
                StudentId = id,
                StudentName = student.Name,
                StudentSurname = student.Surname,
            };
                     
            return View(viewModel);
        }

        //// GET: Grades/Details/5
        public ActionResult Details(int id)
        {
            var grade = db.Grades.Find(id);
           var student = sc.Students.Find(grade.StudentId);

            var viewModel = new GradeDetailsViewModel
            {
                Grade = grade,
                Name = student.Name,
                Surname = student.Surname
               
            };

            return View(viewModel);
        }

        // GET: Grades/Create
        public ActionResult Create(int studentId)
        {
            var viewModel = new GradeCreateViewModel        //zrobione
            {
                StudentId = studentId,
            };
            return View(viewModel);
        }

        // POST: Grades/Create
        [HttpPost]
        public ActionResult Create(Grade grade)     //zrobione
        {
            try
            {
                
                db.Grades.Add(grade);
                db.SaveChanges();

                return RedirectToAction("Index","Grades",new{id = grade.StudentId});
            }
            catch
            {
                return View();
            }
        }

        //// GET: Grades/Edit/5
        public ActionResult Edit(int id)
        {
            var grade = db.Grades.Single(x => x.Id == id);
            return View(grade);
        }

        //// POST: Grades/Edit/5
        [HttpPost]
        public ActionResult Edit(Grade grade)
        {
            try
            {
                db.Entry(grade).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index","Grades");
            }
            catch
            {
                return View();
            }
        }

        // GET: Grades/Delete/5
        public ActionResult Delete(int id=0)
        {
            Grade grade = db.Grades.Find(id);

            return View(grade);
        }

        // POST: Grades/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Grade grade = db.Grades.Find(id);
                db.Grades.Remove(grade);
                db.SaveChanges();

                return RedirectToAction("Index","Grades");
            }
            catch
            {
                return View();
            }
        }
    }
}
