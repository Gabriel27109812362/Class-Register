using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekt.Models;

namespace Projekt.ViewModels
{
    public class AuthCreateViewModel
    {
        public int StudentId { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}