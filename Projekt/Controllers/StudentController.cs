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
        public ActionResult Delete(int id)
        {
            Student student = db.Students.Find(id);
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete_student(int id)
        {
            var student = db.Students.Find(id);
            try
            {
                db.Students.Remove(student);
                db.SaveChanges();
             

                return RedirectToAction("Index","Student");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Settings(int id)
        {
            var student = db.Students.Find(id);
            var viewModel = new StudentSettingsViewModel
            {
                Student = student
            };

            return View(viewModel);
            
        }
    }
}
