using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class Trainer
    {


        public int TrainerId { get; set; }
        
        [Required(ErrorMessage = "First Name is required.")]
        [MinLength(2, ErrorMessage = "Should be more than 2 characters")]
        [MaxLength(15, ErrorMessage = "Should be less than 15 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last Name is required.")]
        [MinLength(2, ErrorMessage = "Should be more than 2 characters")]
        [MaxLength(15, ErrorMessage = "Should be less than 15 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        public decimal Salary { get; set; }
        
        [Required]
        [Display(Name ="Date hired")]
        public DateTime DateHired { get; set; }
        
        [Display(Name ="Availability")]
        public bool IsAvailable { get; set; }

        //Navigation properties
        public virtual ICollection<Specialization> Specializations { get; set; }

    }
}