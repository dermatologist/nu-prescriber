using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NuPrescriber.Models.PrescriptionViewModels
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        public string Name { get; set; }
        public string Department { get; set; }
        public string Qualification { get; set; }

    }
}
