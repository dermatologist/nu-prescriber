namespace NuPrescriber.Models.PrescriptionViewModels
{
    public class IngredientProprietary
    {
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int ProprietaryId { get; set; }
        public Proprietary Proprietary { get; set; }
    }
}