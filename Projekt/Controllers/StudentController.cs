using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Projekt.DataAccessLayer;
using Projekt.Models;
using Projekt.ViewModels;

namespace Projekt.Controllers
{
    public class StudentController : Controller
    {

        private StudentsContext db = new StudentsContext();
        // GET: Student
        public ActionResult Index()
        {
            var students = from std in db.Students
                orderby std.Id
                select std;
            
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Students.Find(id));
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student std)
        {
            try
            {
                db.Students.Add(std);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = db.Students.Single(x => x.Id == id); 
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            try
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id=0)
        {
            Student student = db.Students.Find(id);
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Student student = db.Students.Find(id);
                db.Students.Remove(student);
                db.SaveChanges();
             

                return RedirectToAction("Index","Student");
            }
            catch
            {
                return View();
            }
        }

        //public ActionResult ShowGrades(int id)
        //{
        //    var student = db.Students.Find(id);

        //    var viewModel = new ShowGradesViewModel
        //    {
        //        Grades = student.Grades,
        //        StudentId = id
                
        //    };


        //    return View(viewModel);
        //}

        //public ActionResult AddGrade(int id)
        //{
        //    var viewModel = new GradeViewModel()
        //    {
        //        StudentId = id
        //    };

        //    return View(viewModel);
        //}
        //[HttpPost]
        //public ActionResult AddGrade(int id, float grade)
        //{
        //    try
        //    {
        //        db.Students.Find(id).Grades.Add(grade);
        //        db.SaveChanges();
        //        return RedirectToAction("ShowGrades");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
           

            
        //}

        //public ActionResult DeleteGrade(int id, int studentId)
        //{
        //    var grade = db.Students.Find(studentId).Grades[id];
        //    var viewModel = new GradeViewModel
        //    {
        //        Grade = grade,
        //        StudentId = studentId
        //    };

        //    return View(viewModel);
        //}

        //[HttpPost, ActionName("DeleteGrade")]
        //public ActionResult Delete_Gr(int id, int studentId)
        //{
        //    try
        //    {
        //        db.Students.Find(studentId).Grades.RemoveAt(id);
        //        db.SaveChanges();
        //        return RedirectToAction("ShowGrades");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
           
        //}

        //public ActionResult AddAuth()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddAuth(Auth auth)
        //{
        //    try
        //    {
        //        db.Auths.Add(auth);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //public ActionResult EditAuth()
        //{
        //    return View();
            
        //}

        //[HttpPost]
        //public ActionResult EditAuth()
        //{
        //    return View();
        //}
    }
}
