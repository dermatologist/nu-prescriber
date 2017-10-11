using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuPrescriber.Models.PrescriptionViewModels
{
    public class PrescribedDrug
    {
        public int PrescribedDrugId { get; set; }

        public string Dose { get; set; }
        public string Duration { get; set; }
        public string Frequency { get; set; }
        public string Instructions { get; set; }
        public int PrescriptionId { get; set; } 
        public Prescription Prescription { get; set; }

        public int ProprietaryId { get; set; }
        public Proprietary Proprietary { get; set; }
    }
}
