using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Ingredients")]
        public virtual ICollection<IngredientProprietary> IngredientsProprietaries { get; set; }
    }
}
