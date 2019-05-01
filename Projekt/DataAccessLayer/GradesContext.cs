using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Projekt.Models;

namespace Projekt.DataAccessLayer
{
    public class GradesContext:DbContext
    {
        public GradesContext() : base("ClassRegisterConnection") { }

        public DbSet<Grade> Grades { get; set; }
    }
}