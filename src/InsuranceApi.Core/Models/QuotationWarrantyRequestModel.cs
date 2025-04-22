namespace InsuranceApi.Core.Models
{
    public class QuotationWarrantyRequestModel
    {
        public int QuotationWarrantyId { get; set; }
        public DateTime QuotationDate { get; set; }
        public int ProductVersionId { get; set; }
        public int BrokerId { get; set; }
        public int BorrowerId { get; set; }
        public int TermTypeId { get; set; }
        public int NumberDays { get; set; }
        public DateTime StartCoverage { get; set; }
        public DateTime EndCoverage { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal ValueTotalIs { get; set; }
        public decimal PercentageDiscount { get; set; }
        public decimal PercentageCommission { get; set; }
        public decimal PercentageGrievance { get; set; }
        public IEnumerable<QuotationCoBrokerRequest> CoBroker { get; set; } = [];
    }
}
