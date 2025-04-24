using InsuranceApi.Core.Entities.Enumerators;

namespace InsuranceApi.Core.Models
{
    public class WarrantyRequestModel
    {
        public required string InsuredObject { get; set; }
        public int TermTypeId { get; set; }
        public List<int> LegalRecourseType { get; set; } = [];
        public decimal AppealDepositAmount { get; set; }
        public decimal AppealDepositAmountMax { get; set; }
        public decimal PercentageGrievance { get; set; }
        public decimal InsuredAmountValue { get; set; }
        public string? LegalCasenumber { get; set; }
        public int? LaborCourtId { get; set; }
        public int? CivilCourt { get; set; }
        public InsuredTypeEnum? InsuredType { get; set; }
    }
}
