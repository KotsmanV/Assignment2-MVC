using Assignment2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Models.ViewModels
{
    public class TrainerEditVM
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();

        public Trainer Trainer { get; set; }

        public TrainerEditVM(Trainer trainer)
        {
            Trainer = trainer;
        }

        public IEnumerable<SelectListItem> SpecializationIds
        {
            get
            {
                var trainerSpecsIds = Trainer.Specializations.Select(i=>i.SpecializationId);

                return db.Specializations.ToList().Select(x => new SelectListItem()
                {
                    Value = x.SpecializationId.ToString(),
                    Text = x.SpecializationType,
                    Selected = trainerSpecsIds.Any(y => y==x.SpecializationId)
                }).OrderBy(x=>x.Text) ;
            }
        }
    }
}