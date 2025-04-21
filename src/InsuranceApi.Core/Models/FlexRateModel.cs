namespace InsuranceApi.Core.Models
{
    public class FlexRateModel
    {
        public int FlexRateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ComissionMaxValue { get; set; }
        public decimal InsuredAmountValueMin { get; set; }
        public decimal InsuredAmountValueMax { get; set; }
        public bool IsByValue { get; set; }
        public decimal OperationMaxValue { get; set; }
        public decimal OperationMinValue { get; set; }
        public DateTime? EffectiveDateStart { get; set; }
        public DateTime? EffectiveDateEnd { get; set; }
    }
}
