using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class Broker : IIdentityEntity
    {
        public int BrokerId { get; set; }
        public long? PersonId { get; set; }
        public int? BrokerExternalId { get; set; }
        public virtual Person Person { get; set; } = null!;

        public virtual ICollection<FlexRateBroker> FlexRateBroker { get; set; } = new HashSet<FlexRateBroker>();
    }
}
