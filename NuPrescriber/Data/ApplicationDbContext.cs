using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NuPrescriber.Models;
using NuPrescriber.Models.PrescriptionViewModels;

namespace NuPrescriber.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Proprietary> Proprietaries { get; set; }
        public DbSet<PrescribedDrug> PrescribedDrugs { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<IngredientProprietary> IngredientsProprietaries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IngredientProprietary>()
                .HasKey(ip => new { ip.IngredientId, ip.ProprietaryId });

            builder.Entity<IngredientProprietary>()
                .HasOne(ip => ip.Ingredient)
                .WithMany(ip => ip.IngredientProprietaries)
                .HasForeignKey(ip => ip.IngredientId);

            builder.Entity<IngredientProprietary>()
                .HasOne(ip => ip.Proprietary)
                .WithMany(ip => ip.IngredientsProprietaries)
                .HasForeignKey(ip => ip.ProprietaryId);
        }
    }
}
