using InsuranceApi.Core.Entities;

namespace InsuranceApi.Core.Models
{
    public class CreateQuotationModel
    {
        public int? QuotationId { get; set; }
        public int? QuotationNumber { get; set; }
        public int? VersionNumber { get; set; }
        public int? EndorsementId { get; set; }
        public DateTime QuotationDate { get; set; }
        public int ProductVersionId { get; set; }
        public int BrokerId { get; set; }
        public int InsuranceTypeId { get; set; }
        public int CalculationTypeId { get; set; }
        public int CalculationNumberDay { get; set; }
        public DateTime StartCoverage { get; set; }
        public DateTime EndCoverage { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int QuotationStatusId { get; set; }
        public decimal PercentageDiscount { get; set; }
        public decimal PercentageCommission { get; set; }
        public int? RenovationInsurerId { get; set; }
        public string? RenovationPolicyNumber { get; set; }
        public required QuotationInsuredModel Insured { get; set; }
    }
}
