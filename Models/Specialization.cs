using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class Specialization
    {
        public int SpecializationId { get; set; }
        [Required(ErrorMessage = "Specialization must have a title.")]
        [Display(Name = "Specialization:")]
        public string SpecializationType { get; set; }

        //Navigation properties
        public virtual ICollection<Trainer> Trainers { get; set; }

    }
}