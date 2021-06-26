using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment2.DAL;
using Assignment2.Models;
using Assignment2.Models.ViewModels;
using Assignment2.Repositories;

namespace Assignment2.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private readonly TrainerRepo trainerRepo = new TrainerRepo();

        // GET: Trainer
        public ActionResult Index()
        {
            return View(trainerRepo.GetAll());
        }

        // GET: Trainer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = trainerRepo.FindById(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainer/Create
        public ActionResult Create()
        {
            TrainerCreateVM tc = new TrainerCreateVM();
            //ViewBag.TrainerSpecializations = new SelectList(db.Specializations.ToList(), "Specialization", "Specialization");
            //TrainerSpecializationViewBags();
            return View(tc);
        }

        // POST: Trainer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainerId,FirstName,LastName,Salary,DateHired,IsAvailable")] Trainer trainer, IEnumerable<int>SpecializationIds)
        {
            if (ModelState.IsValid)
            {
                trainerRepo.Create(trainer, SpecializationIds);
                return RedirectToAction("Index");
            }
            TrainerCreateVM tc = new TrainerCreateVM();
            //TrainerSpecializationViewBags();
            return View(tc);
        }

        // GET: Trainer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = trainerRepo.FindById(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            TrainerEditVM te = new TrainerEditVM(trainer);
            return View(te);
        }
        // POST: Trainer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainerId,FirstName,LastName,Salary,DateHired,IsAvailable")] Trainer trainer, IEnumerable<int> SpecializationIds)
        {
            //TODO 1: Highlight selected specializations.
            if (ModelState.IsValid)
            {
                trainerRepo.Edit(trainer, SpecializationIds);
                return RedirectToAction("Index");
            }
            trainerRepo.Attach(trainer);
            TrainerEditVM te = new TrainerEditVM(trainer);
            return View(te);
        }

        // GET: Trainer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = trainerRepo.FindById(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trainerRepo.Delete(id);
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void TrainerSpecializationViewBags()
        {
            var specs = db.Specializations.ToList();

            ViewBag.TrainerSpecializations = new SelectList(specs, "Specialization", "Specialization");
        }
    }
}
