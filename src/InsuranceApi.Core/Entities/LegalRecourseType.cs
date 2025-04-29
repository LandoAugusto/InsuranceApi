using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class LegalRecourseType : IIdentityEntity
    {
        public int LegalRecourseTypeId { get; set; }
        public string Name { get; set; }        
        public string? LegacyCode { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual ICollection<LegalRecourseTypeParameter> LegalRecourseTypeParameter { get; set; } = new HashSet<LegalRecourseTypeParameter>();
    }
}
