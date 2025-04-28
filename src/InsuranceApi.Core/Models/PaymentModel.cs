namespace InsuranceApi.Core.Models
{
    public class PaymentModel
    {
        public int PaymentMethod { get; set; }
        public int PaymentFrequency { get; set; }
        public int PaymentInstallmentId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
