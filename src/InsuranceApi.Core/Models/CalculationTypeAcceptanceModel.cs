namespace InsuranceApi.Core.Models
{
    public class CalculationTypeAcceptanceModel
    {
        public int ProductVersionCalculationTypeId { get; set; }
        public bool IsCountDays { get; set; }
        public int CountDayMin { get; set; }
        public int CountDayMax { get; set; }
    }
}
