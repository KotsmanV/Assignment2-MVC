using Assignment2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Models.ViewModels
{
    public class TrainerCreateVM
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<SelectListItem> SpecializationIds
        {
            get
            {
                return db.Specializations.ToList().Select(x => new SelectListItem()
                {
                    Value = x.SpecializationId.ToString(),
                    Text = x.SpecializationType
                });
            }
        }

        public Trainer Trainer { get; set; }

    }
}