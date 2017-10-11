using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NuPrescriber.Data.Migrations
{
    public partial class PrescriptionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Department = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Qualification = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Quantity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Age = table.Column<decimal>(nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Proprietaries",
                columns: table => new
                {
                    ProprietaryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredientId = table.Column<int>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietaries", x => x.ProprietaryId);
                    table.ForeignKey(
                        name: "FK_Proprietaries_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    AllergyId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredientId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.AllergyId);
                    table.ForeignKey(
                        name: "FK_Allergies_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allergies_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.PrescriptionId);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescribedDrugs",
                columns: table => new
                {
                    PrescribedDrugId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Dose = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    Frequency = table.Column<string>(nullable: true),
                    Instructions = table.Column<string>(nullable: true),
                    PrescriptionId = table.Column<int>(nullable: false),
                    ProprietaryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescribedDrugs", x => x.PrescribedDrugId);
                    table.ForeignKey(
                        name: "FK_PrescribedDrugs_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescribedDrugs_Proprietaries_ProprietaryId",
                        column: x => x.ProprietaryId,
                        principalTable: "Proprietaries",
                        principalColumn: "ProprietaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_IngredientId",
                table: "Allergies",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_PatientId",
                table: "Allergies",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescribedDrugs_PrescriptionId",
                table: "PrescribedDrugs",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescribedDrugs_ProprietaryId",
                table: "PrescribedDrugs",
                column: "ProprietaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorId",
                table: "Prescriptions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Proprietaries_IngredientId",
                table: "Proprietaries",
                column: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "PrescribedDrugs");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Proprietaries");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
