using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Projekt.Models;

namespace Projekt.DataAccessLayer
{
    public class AuthContext: DbContext
    {
        public AuthContext() : base("ClassRegisterConnection") { }

        public DbSet<Auth> Auths { get; set; }
    }
}