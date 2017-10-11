using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuPrescriber.Models.PrescriptionViewModels
{
    public class Allergy
    {
        public int AllergyId { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public string Type { get; set; }
        public string Notes { get; set; }

    }
}
