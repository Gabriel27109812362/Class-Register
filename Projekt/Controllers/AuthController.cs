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
    public class AuthController : Controller
    {
        //// GET: Auth
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: Auth/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Auth/Create
        private AuthContext db = new AuthContext();
        private StudentsContext sc = new StudentsContext();
        public ActionResult Create(int id)
        {
            var student = sc.Students.Find(id);
            var auth = db.Auths.Find(id);

            if (auth != null)
            {
                var viewModel = new AuthExistViewModel()
                {
                    Student = student
                };
                return View("AuthExist",viewModel);
            }
            else
            {
                var viewModel = new AuthCreateViewModel
                {
                    Id = student.Id
                };
                return View("Create",viewModel);
            }

            
        }

        // POST: Auth/Create
        [HttpPost]
        public ActionResult Create(Auth auth)
        {
            try
            {
                db.Auths.Add(auth);
                db.SaveChanges();

                return RedirectToAction("Index","Student");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auth/Edit/5
        public ActionResult Edit(int id)
        {
            var student = sc.Students.Find(id);
            var auth = db.Auths.Find(id);

            if (auth == null)
            {
                var viewModel = new AuthNotExistViewModel
                {
                    Student = student
                };
                return View("AuthNotExist", viewModel);
            }
            else
            {
                var viewModel = new AuthEditViewModel
                {
                    Id = student.Id
                };
                return View("Edit", viewModel);
            }

            
        }

        // POST: Auth/Edit/5
        [HttpPost]
        public ActionResult Edit(Auth auth)
        {
            try
            {
                db.Entry(auth).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Student");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auth/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Auth/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
