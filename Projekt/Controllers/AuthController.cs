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

    }
}
