using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekt.Models;

namespace Projekt.ViewModels
{
    public class GradeDetailsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Grade Grade { get; set; }
    }
}