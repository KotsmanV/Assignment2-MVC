using Assignment2.DAL;
using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment2.Repositories
{
    public class TrainerRepo
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();

        public List<Trainer> GetAll()
        {
            return db.Trainers.ToList();
        }

        public Trainer FindById(int? id)
        {
            return db.Trainers.Find(id);
        }

        public void Create(Trainer trainer, IEnumerable<int> SpecializationIds)
        {
            db.Trainers.Attach(trainer);
            db.Entry(trainer).Collection("Specializations").Load();
            trainer.Specializations.Clear();
            db.SaveChanges();

            if (SpecializationIds!=null)
            {
                foreach (var id in SpecializationIds )
                {
                    Specialization spec = db.Specializations.Find(id);
                    if (spec != null)
                        trainer.Specializations.Add(spec);
                }
            }

            db.Entry(trainer).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(Trainer trainer, IEnumerable<int> SpecializationIds)
        {
            db.Trainers.Attach(trainer);
            db.Entry(trainer).Collection("Specializations").Load();
            trainer.Specializations.Clear();
            db.SaveChanges();

            if (SpecializationIds != null)
            {
                foreach (var id in SpecializationIds)
                {
                    Specialization spec = db.Specializations.Find(id);
                    if (spec != null)
                    {
                        trainer.Specializations.Add(spec);
                    }
                }
            }
            db.Entry(trainer).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Attach(Trainer trainer)
        {
            db.Trainers.Attach(trainer);
            db.Entry(trainer).Collection("Specializations").Load();
        }

        public void Delete(int id)
        {
            Trainer trainer = db.Trainers.Find(id);
            trainer.Specializations.Clear();

            db.Entry(trainer).State = EntityState.Deleted;
            db.SaveChanges();
        }

        private readonly bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}