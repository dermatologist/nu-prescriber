using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuPrescriber.Models.PrescriptionViewModels
{
    public enum Gender
    {
        Male,
        Female,
        UnKnown,
        NotDisclosed
    }
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public decimal Age { get; set; }
        public Gender Gender { get; set; }
        public DateTime Dob { get; set; }

    }
}
