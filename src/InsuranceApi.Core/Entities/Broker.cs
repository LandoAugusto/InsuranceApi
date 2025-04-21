using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class Broker : IIdentityEntity
    {
        public int BrokerId { get; set; }
        public long? PersonId { get; set; }
        public string? SusepCode { get; set; }
        public int LegacyUserId { get; set; }
        public string? LegacyCode { get; set; }
        public string? AddressLegacyCode { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }

        public virtual Person Person { get; set; } = null!;

        public virtual ICollection<FlexRateBroker> FlexRateBroker { get; set; } = new HashSet<FlexRateBroker>();
    }
}
