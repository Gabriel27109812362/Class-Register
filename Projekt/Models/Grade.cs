using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class Grade
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        public float Value { get; set; }

        [ForeignKey("Student"), Column(Order = 2)]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}