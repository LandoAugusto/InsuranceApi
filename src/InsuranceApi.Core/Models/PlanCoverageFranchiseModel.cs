namespace InsuranceApi.Core.Models
{
    public class PlanCoverageFranchiseModel
    {    
        public int CoverageId { get; set; }
        public  string Name { get; set; }
        public  string Description { get; set; }
        public int BranchId { get; set; }
        public int CoverageGroupId { get; set; }
        public bool CoverageBasic { get; set; }
        public int? CoverageRestricted { get; set; }
        public decimal InsuredAmountMin { get; set; }
        public decimal InsuredAmountMax { get; set; }
        public List<FranchiseModel> Franchise { get; set; } = [];        

    }
}
