using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class FlexRateBroker : IIdentityEntity { 
        
        public int FlexRateBrokerId { get; set; }
        public int FlexRateId { get; set; }
        public int BrokerId { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        public DateTime DateUtc { get; set; }
        public virtual Broker Broker { get; set; } = null!;
        public virtual FlexRate FlexRate { get; set; } = null!;

    }
}