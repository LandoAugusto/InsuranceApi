namespace InsuranceApi.Core.Models
{
    public class LegalRecourseTypeModel
    {
        public int LegalRecourseTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Status { get; set; }        
        public decimal ApeelDepositAmount { get; set; }
    }
}
