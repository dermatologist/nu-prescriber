using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuPrescriber.Models.PrescriptionViewModels
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<IngredientProprietary> IngredientProprietaries { get; set; }

    }
}
