using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekt.DataAccessLayer;
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
                
                
               var studentAuth= from std in db.Auths
                    where std.Login == login && std.Password == password
                    select std;
               if (!studentAuth.Any())
               {
                   return View("WrongAuthData");
               }
               else
               {
                   
               }

               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
