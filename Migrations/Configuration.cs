namespace Assignment2.Migrations
{
    using Assignment2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment2.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Assignment2.DAL.ApplicationDbContext context)
        {

            try
            {
                Specialization s1 = new Specialization() { SpecializationType = "Drums" };
                Specialization s2 = new Specialization() { SpecializationType = "Vocals" };
                Specialization s3 = new Specialization() { SpecializationType = "Electric Guitar" };
                Specialization s4 = new Specialization() { SpecializationType = "Electric Bass" };
                Specialization s5 = new Specialization() { SpecializationType = "Theory" };

                context.Specializations.AddOrUpdate(s => s.SpecializationType, s1, s2, s3, s4, s5);

                Trainer t1 = new Trainer() { FirstName = "Naomi", LastName = "Nagata", Salary = 1021.34m, DateHired = new DateTime(2019, 9, 1), IsAvailable = true };
                t1.Specializations = new List<Specialization>() { s1 };
                Trainer t2 = new Trainer() { FirstName = "James", LastName = "Holden", Salary = 985.73m, DateHired = new DateTime(2019, 9, 1), IsAvailable = true };
                t2.Specializations = new List<Specialization>() { s2 };
                Trainer t3 = new Trainer() { FirstName = "Amos", LastName = "Burton", Salary = 802.14m, DateHired = new DateTime(2019, 9, 1), IsAvailable = true };
                t3.Specializations = new List<Specialization>() { s3, s4 };
                Trainer t4 = new Trainer() { FirstName = "Anderson", LastName = "Dawes", Salary = 1482.99m, DateHired = new DateTime(2013, 3, 6), IsAvailable = false };
                t4.Specializations = new List<Specialization>() { s5 };
                Trainer t5 = new Trainer() { FirstName = "Bobbie", LastName = "Draper", Salary = 1245.75m, DateHired = new DateTime(2015, 8, 3), IsAvailable = false };
                t4.Specializations = new List<Specialization>() { s5 };

                context.Trainers.AddOrUpdate(t => new { t.FirstName, t.LastName }, t1, t2, t3, t4, t5);
                context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }           
    }
}
