using DemoEfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoEfCore.Data
{
    internal class StudentDbContext : DbContext
    {

        public DbSet<Student> students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            string connectionString = "server=localhost;database=demo_efcore;user=root;password=Root;";
            optionbuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        //Creation de la migration
        // 1 - Add-Migration initial
        // 2 - Update-Database

    }
}
