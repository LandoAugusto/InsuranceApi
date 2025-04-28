using InsuranceApi.Core.Entities.Enumerators;

namespace InsuranceApi.Core.Models
{
    public class WarrantyRequestModel
    {   
        public int? TermTypeId { get; set; }
        public int? NumberDays { get; set; }        
        public string? ContractNumber { get; set; }
        public decimal ContractValue { get; set; }
        public string? LegalCasenumber { get; set; }
        public decimal AppealDepositAmount { get; set; }
        public decimal AppealDepositAmountMax { get; set; }
        public decimal PercentageGrievance { get; set; }
        public decimal InsuredAmountValue { get; set; }        
        public int? LaborCourtId { get; set; }
        public int? CivilCourtId { get; set; }        
        public required string InsuredObject { get; set; }
        public InsuredTypeEnum? InsuredTypeId { get; set; }
        public List<int> LegalRecourseType { get; set; } = [];
    }
}
