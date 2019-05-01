using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class Auth
    {

        [Key, ForeignKey("Student")]
        public int StudentAuthId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual Student Student { get; set; }
    }
}