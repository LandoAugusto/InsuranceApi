using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class ProposalBilling : IIdentityEntity
    {

        public int ProposalId { get; set; }
        public int ProposalBillingId { get; set; }
        public virtual Proposal Proposal { get; set; } = null!;
    }
}
