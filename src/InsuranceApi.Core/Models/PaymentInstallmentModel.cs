namespace InsuranceApi.Core.Models
{
    public class PaymentInstallmentModel
    {
        public int PaymentInstallmentId { get; set; }
        public required string Description { get; set; }
        public int NumberOfInstallment { get; set; }
        public int Code { get; set; }
        public bool IsInterest { get; set; }
        public decimal RateInterest { get; set; }
        public decimal Coefficient { get; set; }
    }
}
