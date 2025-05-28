namespace InsuranceApi.Core.Models
{
    public class ClaimsExperienceBonusModel
    {
        public int ClaimsExperienceBonusId { get; set; }
        public required string Name { get; set; }
        public required int BonusId { get; set; }
    }
}
