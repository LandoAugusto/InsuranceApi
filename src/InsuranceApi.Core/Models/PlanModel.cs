namespace InsuranceApi.Core.Models
{
    public  class PlanModel
    {
        public int PlanId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? Image { get; set; }
        public bool IsPersonalized { get; set; }
    }
}
