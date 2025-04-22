namespace InsuranceApi.Core.Models
{
    public class QuotationCoBrokerRequest
    {
        public int BrokerId { get; set; }
        public bool IsMain { get; set; }
        public bool PercentageParticipation { get; set; }
    }
}
