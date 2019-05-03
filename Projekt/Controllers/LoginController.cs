using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Projekt.DataAccessLayer;
using Projekt.Models;
using Projekt.ViewModels;

namespace Projekt.Controllers
{
    public class LoginController : Controller
    {
        private AuthContext db = new AuthContext();
        private StudentsContext sc = new StudentsContext();
        private GradesContext gc = new GradesContext();

        // GET: Login/Authenticate
        public ActionResult Authenticate()
        {
            var viewModel = new LoginAuthenticateViewModel();
            return View("Authenticate",viewModel);
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Authenticate(string login, string password)
        {
            try
            {
                
                
               var studentAuthList= from std in db.Auths
                    where std.Login == login && std.Password == password
                    select std;
               if (!studentAuthList.Any())
               {
                   return View("WrongAuthData");
               }
               else
               {
                   var studentAuth = studentAuthList.ToArray()[0];
                   var student = sc.Students.Find(studentAuth.Id);
                   
                   var viewModel = new LoginSignedViewModel
                   {
                        Student = student
                   };
                   FormsAuthentication.SetAuthCookie(student.Name,false);

                   return View("LoggedStudent",viewModel);
               }                
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var auth = db.Auths.Find(id);

            var viewModel = new AuthEditViewModel
            {
                Id = auth.Id
            };
            return View("Edit", viewModel);
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(Auth auth)
        {
            try
            {
                db.Entry(auth).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Authenticate");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GradeDetails(int id, string name, string surname)
        {
            var grades = from grd in gc.Grades
                where grd.StudentId == id
                select grd;

            var viewModel = new GradeIndexViewModel
            {
                Grades = grades,
                StudentId = id,
                StudentName = name,
                StudentSurname = surname
            };
            
            return View(viewModel);
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Authenticate");
        }

    
    }
}
