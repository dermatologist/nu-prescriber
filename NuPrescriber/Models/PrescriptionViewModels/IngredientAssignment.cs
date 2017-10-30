namespace NuPrescriber.Models.PrescriptionViewModels
{
    public class IngredientAssignment
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public bool Assigned { get; internal set; }
    }
}