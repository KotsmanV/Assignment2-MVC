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
using PagedList;

namespace Assignment2.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private readonly TrainerRepo trainerRepo = new TrainerRepo();

        // GET: Trainer
        public ActionResult Index(string searchText, string selectOption, string sortOrder, int? pSize, int? page )
        {
            var trainers = trainerRepo.GetAll();
            #region Sorting

            ViewBag.ByLastName = String.IsNullOrEmpty(sortOrder) ? "LastNameDesc" : "";
            ViewBag.ByFirstName = sortOrder == "FirstNameAsc" ? "FirstNameDesc" : "FirstNameAsc";
            ViewBag.BySpecialization = sortOrder == "SpecializationAsc" ? "SpecializationDesc" : "SpecializationAsc";
            ViewBag.BySalary = sortOrder == "SalaryAsc" ? "SalaryDesc" : "SalaryAsc";
            ViewBag.ByDateHired = sortOrder == "DateHiredAsc" ? "DateHiredDesc" : "DateHiredAsc";
            ViewBag.ByAvailability = sortOrder == "Available" ? "Unavailable" : "Available";

            switch (sortOrder)
            {
                case "LastNameDesc": trainers = trainers.OrderByDescending(x => x.LastName).ToList(); break;

                case "FirstNameAsc": trainers = trainers.OrderBy(x => x.FirstName).ToList(); break;
                case "FirstNameDesc": trainers = trainers.OrderByDescending(x => x.FirstName).ToList(); break;

                //case "SpecializationAsc": trainers = trainers.OrderBy(x => x.Specializations).ToList(); break;
                //case "SpecializationDesc": trainers = trainers.OrderByDescending(x => x.Specializations).ToList(); break;

                case "DateHiredAsc": trainers = trainers.OrderBy(x => x.DateHired).ToList(); break;
                case "DateHiredDesc": trainers = trainers.OrderByDescending(x => x.DateHired).ToList(); break;
                
                case "SalaryAsc": trainers = trainers.OrderBy(x => x.Salary).ToList(); break;
                case "SalaryDesc": trainers = trainers.OrderByDescending(x => x.Salary).ToList(); break;
                    
                case "Available": trainers = trainers.OrderBy(x => x.IsAvailable).ToList(); break;
                case "Unavailable": trainers = trainers.OrderByDescending(x => x.IsAvailable).ToList(); break;

                default: trainers = trainers.OrderBy(x => x.LastName).ToList(); break;
            }
            #endregion

            #region Filtering
            if (!String.IsNullOrEmpty(searchText))
            {
                switch (selectOption)
                {
                    case "FirstName": trainers = trainers.Where(x => x.FirstName.ToUpper().Contains(searchText.ToUpper())).ToList(); break;
                    case "LastName": trainers = trainers.Where(x => x.LastName.ToUpper().Contains(searchText.ToUpper())).ToList(); break;
                    case "DateHired": trainers = trainers.Where(x => x.DateHired == DateTime.Parse(searchText)).ToList(); break;
                    case "Salary": trainers = trainers.Where(x => x.Salary == Decimal.Parse(searchText)).ToList(); break;
                    case "Specialization": trainers = trainers.Where(x => x.Specializations.Any(y => y.SpecializationType.Equals(searchText))).ToList(); break;
                }
            }
            #endregion

            int pageSize = pSize ?? 10;
            int pageNumber = page ?? 1;
            return View(trainers.ToPagedList(pageNumber,pageSize));
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
            //TODO 5: Check viewmodel instances
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
            trainerRepo.Dispose();
        }

        public void TrainerSpecializationViewBags()
        {
            var specs = db.Specializations.ToList();

            ViewBag.TrainerSpecializations = new SelectList(specs, "Specialization", "Specialization");
        }
    }
}
