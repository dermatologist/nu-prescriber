using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NuPrescriber.Models.PrescriptionViewModels
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Display(Name = "Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "Prescribed Drugs")]
        public ICollection<PrescribedDrug> PrescribedDrugs { get; set; }
    }
}
