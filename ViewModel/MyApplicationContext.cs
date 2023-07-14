using BookMedicinalPlants.Model;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System;


namespace BookMedicinalPlants.ViewModel
{


    public class MyApplicationContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-N6GODSK;Database=PlantsDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
