namespace InsuranceApi.Core.Models
{
    public class QuotationWarrantyRequestModel
    {
        public int QuotationWarrantyId { get; set; }
        public DateTime QuotationDate { get; set; }
        public int ProductVersionId { get; set; }
        public int BrokerId { get; set; }
        public int BorrowerId { get; set; }
        public DateTime StartCoverage { get; set; }
        public DateTime EndCoverage { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal PercentageDiscount { get; set; }
        public decimal PercentageCommission { get; set; }        
        public required IEnumerable<PersonModelRequest> Person { get; set; }
        public required WarrantyRequestModel Warranty { get; set; }
        public IEnumerable<QuotationCoBrokerRequest>? CoBroker { get; set; } = [];
        public PaymentModel? Payment { get; set; }
    }
}
