using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Projekt.Models;

namespace Projekt.DataAccessLayer
{
    public class StudentsContext: DbContext
    {
        public StudentsContext(): base("ClassRegisterConnection") { }

        public DbSet<Student> Students { get; set; }

    }
}