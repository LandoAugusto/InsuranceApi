namespace InsuranceApi.Core.Models
{
    public class SimulationFilterModel
    {
        //-- Dados utilizados para simulação
        public int FlexRateMixId { get; set; }
        public DateTime StartOfTerm { get; set; }
        public DateTime EndOfTerm { get; set; }
        public decimal SimulationFlexRateValue { get; set; }
        public decimal SimulationInsuredAmountValue { get; set; }
        public decimal SimulationPremiumValue { get; set; }
        public decimal SimulationComissionPercentage { get; set; }
        public decimal SimulationComissionValue { get; set; }
    }
}
