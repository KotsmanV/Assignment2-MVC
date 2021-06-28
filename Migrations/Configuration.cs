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
                Specialization s5 = new Specialization() { SpecializationType = "Popular Music Theory" };
                Specialization s6 = new Specialization() { SpecializationType = "Violin" };
                Specialization s7 = new Specialization() { SpecializationType = "Piano" };
                Specialization s8 = new Specialization() { SpecializationType = "Trumpet" };
                Specialization s9 = new Specialization() { SpecializationType = "Saxophone" };
                Specialization s10 = new Specialization() { SpecializationType = "Flute" };
                Specialization s11 = new Specialization() { SpecializationType = "Harp" };
                Specialization s12 = new Specialization() { SpecializationType = "Bassoon" };
                Specialization s13 = new Specialization() { SpecializationType = "Clarinet" };
                Specialization s14 = new Specialization() { SpecializationType = "Opera" };
                Specialization s15 = new Specialization() { SpecializationType = "Classical Music Theory" };

                context.Specializations.AddOrUpdate(s => s.SpecializationType, s1, s2, s3, s4, s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15);

                Trainer t1 = new Trainer() { FirstName = "Naomi", LastName = "Nagata", Salary = 1021.34m, DateHired = new DateTime(2019, 9, 1), IsAvailable = true, Specializations = new List<Specialization>() { s1 } };
                Trainer t2 = new Trainer() { FirstName = "James", LastName = "Holden", Salary = 985.73m, DateHired = new DateTime(2019, 9, 1), IsAvailable = true, Specializations = new List<Specialization>() { s2,s14 } };
                Trainer t3 = new Trainer() { FirstName = "Amos", LastName = "Burton", Salary = 802.14m, DateHired = new DateTime(2019, 9, 1), IsAvailable = true, Specializations = new List<Specialization>() { s3, s4 } };
                Trainer t4 = new Trainer() { FirstName = "Anderson", LastName = "Dawes", Salary = 1482.99m, DateHired = new DateTime(2013, 3, 6), IsAvailable = false, Specializations = new List<Specialization>() { s5,s15 } };
                Trainer t5 = new Trainer() { FirstName = "Bobbie", LastName = "Draper", Salary = 1245.75m, DateHired = new DateTime(2015, 8, 3), IsAvailable = false, Specializations = new List<Specialization>() { s5,s15,s7 } };
                Trainer t6 = new Trainer() { FirstName = "Chrisjen", LastName = "Avasarala", Salary = 1467.21m, DateHired = new DateTime(2012, 1, 15), IsAvailable = true, Specializations = new List<Specialization>() { s5,s15,s7 } };
                Trainer t7 = new Trainer() { FirstName = "Marco", LastName = "Inaros", Salary = 543.34m, DateHired = new DateTime(2020, 9, 15), IsAvailable = true, Specializations = new List<Specialization>() { s12,s13 } };
                Trainer t8 = new Trainer() { FirstName = "Camina", LastName = "Drummer", Salary = 1130.11m, DateHired = new DateTime(2018, 10, 1), IsAvailable = true, Specializations = new List<Specialization>() { s8,s9 } };
                Trainer t9 = new Trainer() { FirstName = "Dmitri", LastName = "Havelock", Salary = 1421.34m, DateHired = new DateTime(2016, 12, 8), IsAvailable = false, Specializations = new List<Specialization>() { s5,s11,s8 } };
                Trainer t10 = new Trainer() { FirstName = "Clarissa", LastName = "Mao", Salary = 1435.12m, DateHired = new DateTime(2021, 7, 23), IsAvailable = false, Specializations = new List<Specialization>() { s7, s4, s1 } };
                Trainer t11 = new Trainer() { FirstName = "Juliette", LastName = "Mao", Salary = 1679.98m, DateHired = new DateTime(2020, 7, 23), IsAvailable = false, Specializations = new List<Specialization>() { s8, s6, s12 } };
                Trainer t12 = new Trainer() { FirstName = "Alex", LastName = "Kamal", Salary = 789.23m, DateHired = new DateTime(2012, 10, 2), IsAvailable = true, Specializations = new List<Specialization>() { s15, s12, s10 } };
                Trainer t13 = new Trainer() { FirstName = "Fred", LastName = "Johnson", Salary = 987.19m, DateHired = new DateTime(2014, 11, 26), IsAvailable = true, Specializations = new List<Specialization>() { s9, s3, s11 } };
                Trainer t14 = new Trainer() { FirstName = "Michio", LastName = "Pa", Salary = 665.76m, DateHired = new DateTime(2017, 11, 12), IsAvailable = false, Specializations = new List<Specialization>() { s5, s6, s9 } };
                Trainer t15 = new Trainer() { FirstName = "Solomon", LastName = "Epstein", Salary = 665.76m, DateHired = new DateTime(2018, 12, 25), IsAvailable = true, Specializations = new List<Specialization>() { s10, s5, s1 } };
                context.Trainers.AddOrUpdate(t => new { t.FirstName, t.LastName, }, t1, t2, t3, t4, t5,t6,t7,t8,t9);
                context.Trainers.AddOrUpdate(t => new { t.FirstName, t.LastName, }, t10, t11, t12, t13, t14,t15);

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
