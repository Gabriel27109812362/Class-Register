using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekt.Models;

namespace Projekt.ViewModels
{
    public class GradeIndexViewModel
    {
        public IQueryable<Grade> Grades { get; set; }

        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public string StudentSurname { get; set; }
      
    }
}