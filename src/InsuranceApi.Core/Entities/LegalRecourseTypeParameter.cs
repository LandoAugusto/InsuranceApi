using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class LegalRecourseTypeParameter : IIdentityEntity
    {
        public int? LegalRecourseTypeParameterId { get; set; }
        public int LegalRecourseTypeId { get; set; }
        public decimal ApeelDepositAmount { get; set; }
        public DateTime StartCoverage { get; set; }
        public DateTime? EndCoverage { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual LegalRecourseType LegalRecourseType { get; set; } = null!;
    }
}
