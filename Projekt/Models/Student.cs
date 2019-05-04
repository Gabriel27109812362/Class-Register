using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required, Range(6,99,ErrorMessage = "Należy wpisać liczbę w przedziału od 6-99")]
        public int Age { get; set; }

        public virtual Auth Auth { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }

    }
}