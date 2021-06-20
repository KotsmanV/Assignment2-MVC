using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment2.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext():base("MyDataBase")
        {
        }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

    }
}