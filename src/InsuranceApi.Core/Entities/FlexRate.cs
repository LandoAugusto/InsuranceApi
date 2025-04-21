using Guarantee.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class FlexRate : IIdentityEntity
    {
        public int FlexRateId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int RateTypeId { get; set; }
        public int? ProductVersionId { get; set; }
        public decimal ComissionMaxValue { get; set; }
        public decimal InsuredAmountValueMin { get; set; }
        public decimal InsuredAmountValueMax { get; set; }
        public bool IsByValue { get; set; }
        public int OperationTypeId { get; set; }
        public decimal OperationMinValue { get; set; }
        public decimal OperationMaxValue { get; set; }   
        public DateTime? EffectiveDateStart { get; set; }
        public DateTime? EffectiveDateEnd { get; set; }
        public RecordStatusEnum? Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }        
        public virtual RateType RateType { get; set; } = null!;
        public virtual OperationType OperationType { get; set; } = null!;
        public virtual ICollection<FlexRateBroker> FlexRateBroker { get; set; } = new HashSet<FlexRateBroker>();
    }
}