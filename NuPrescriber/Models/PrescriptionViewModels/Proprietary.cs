using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuPrescriber.Models.PrescriptionViewModels
{
    public class Proprietary
    {
        public int ProprietaryId { get; set; }


        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Price { get; set; }
        public string Notes { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
