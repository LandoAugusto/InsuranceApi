namespace InsuranceApi.Core.Models
{
    public class InsurerModel
    {
        public int InsurerId { get; set; }
        public required string Name { get; set; }
        public required string CodeNumber { get; set; }
        public int LegacyCode { get; set; }
        public bool IsLeader { get; set; }
        public bool IsCongenere { get; set; }
    }
}
