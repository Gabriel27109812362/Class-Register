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
        //// GET: Login
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: Login/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}
        private AuthContext db = new AuthContext();
        private StudentsContext sc = new StudentsContext();
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

            return View();
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Authenticate");
        }

    
    }
}
