using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NuPrescriber.Data;
using NuPrescriber.Models.PrescriptionViewModels;

namespace NuPrescriber.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171031151947_DoctorUpdate")]
    partial class DoctorUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("NuPrescriber.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("NuPrescriber.Models.PrescriptionViewModels.Allergy", b =>
                {
                    b.Property<int>("AllergyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IngredientId");

                    b.Property<string>("Notes");

                    b.Property<int>("PatientId");

                    b.Property<string>("Type");

                    b.HasKey("AllergyId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("PatientId");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("NuPrescriber.Models.PrescriptionViewModels.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Department");

                    b.Property<string>("Hospital");

                    b.Property<string>("Name");

                    b.Property<string>("Qualification");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("NuPrescriber.Models.PrescriptionViewModels.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("Quantity");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("NuPrescriber.Models.PrescriptionViewModels.IngredientProprietary", b =>
                {
                    b.Property<int>("IngredientId");

                    b.Property<int>("ProprietaryId");

                    b.HasKey("IngredientId", "ProprietaryId");

                    b.HasIndex("ProprietaryId");

                    b.ToTable("IngredientsProprietaries");
                });

            modelBuilder.Entity("NuPrescriber.Models.PrescriptionViewModels.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Age");

                    b.Property<DateTime>("Dob");

                    b.Property<int>("Gender");

                    b.Property<string>("Name");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("NuPrescriber.Models.PrescriptionViewModels.PrescribedDrug", b =>
                {
                    b.Property<int>("PrescribedDrugId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Dose");

                    b.Property<string>("Duration");

                    b.Property<string>("Frequency");

                    b.Property<string>("Instructions");

                    b.Property<int>("PrescriptionId");

                    b.Property<int>("ProprietaryId");

                    b.HasKey("PrescribedDrugId");

                    b.HasIndex("PrescriptionId");

                    b.HasIndex("ProprietaryId");

                    b.ToTable("PrescribedDrugs");
                });

            modelBuilder.Entity("NuPrescriber.Models.PrescriptionViewModels.Prescription", b =>
                {
                    b.Property<int>("PrescriptionId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("DoctorId");

                    b.Property<int>("PatientId");

                    b.HasKey("PrescriptionId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("NuPrescriber.Models.PrescriptionViewModels.Proprietary", b =>
                {
                    b.Property<int>("ProprietaryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("Price");

                    b.HasKey("ProprietaryId");

                    b.ToTable("Proprietaries");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NuPrescriber.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NuPrescriber.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NuPrescriber.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NuPrescriber.Models.PrescriptionViewModels.Allergy", b =>
                {
                    b.HasOne("NuPrescriber.Models.PrescriptionViewModels.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NuPrescriber.Models.PrescriptionViewModels.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NuPrescriber.Models.PrescriptionViewModels.IngredientProprietary", b =>
                {
                    b.HasOne("NuPrescriber.Models.PrescriptionViewModels.Ingredient", "Ingredient")
                        .WithMany("IngredientProprietaries")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NuPrescriber.Models.PrescriptionViewModels.Proprietary", "Proprietary")
                        .WithMany("IngredientsProprietaries")
                        .HasForeignKey("ProprietaryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NuPrescriber.Models.PrescriptionViewModels.PrescribedDrug", b =>
                {
                    b.HasOne("NuPrescriber.Models.PrescriptionViewModels.Prescription", "Prescription")
                        .WithMany("PrescribedDrugs")
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NuPrescriber.Models.PrescriptionViewModels.Proprietary", "Proprietary")
                        .WithMany()
                        .HasForeignKey("ProprietaryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NuPrescriber.Models.PrescriptionViewModels.Prescription", b =>
                {
                    b.HasOne("NuPrescriber.Models.PrescriptionViewModels.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NuPrescriber.Models.PrescriptionViewModels.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
