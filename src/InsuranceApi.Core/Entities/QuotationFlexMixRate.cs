using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class QuotationFlexMixRate : IIdentityEntity
    {
        //-- Dados utilizados para simulação
        public int? QuotationFlexMixRateId { get; set; }
        public int? FlexRateMixId { get; set; }
        public int SimulationRateType { get; set; }
        public int SimulationOperationTypeId { get; set; }
        public bool SimulationIsByValue { get; set; }
        public decimal SimulationFlexRateValue { get; set; }
        public decimal SimulationInsuredAmountValue { get; set; }
        public decimal? SimulationRiskRatioValue { get; set; }
        public int SimulationValidDays { get; set; }
        public decimal SimulationPremiumValue { get; set; }
        public decimal SimulationComissionMaxValue { get; set; }
        public decimal SimulationComissionPercentage { get; set; }
        public decimal SimulationComissionValue { get; set; }
        //-- Dados calculados

        public decimal? CalculatedRateValue { get; set; }
        public decimal? CalculatedPremiumValue { get; set; }
        public decimal? CalculatedPremiumDifferenceValue { get; set; }
        public decimal? CalculatedPremiumDifferencePercentage { get; set; }
        public decimal? CalculatedComissionValue { get; set; }
        public decimal? CalculatedComissionPercentage { get; set; }
        public decimal? CalculatedComissionDifferenceValue { get; set; }
        public decimal? CalculatedComissionDifferencePercentage { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }

    }
}
