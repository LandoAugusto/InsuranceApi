namespace InsuranceApi.Core.Models
{
    public class PlanCoverageActivityLimit
    {    
     
        public int CoverageId { get; set; }
        public  string Name { get; set; }
        public  string Description { get; set; }
        public int BranchId { get; set; }
        public int CoverageGroupId { get; set; }
        public bool CoverageBasic { get; set; }
        public int? CoverageRestricted { get; set; }        
        public  CoverageActivityLimitModel Limit { get; set; }
    }
}
