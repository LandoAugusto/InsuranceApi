using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class Proposal : IIdentityEntity
    {
        public int ProposalId { get; set; }
        public int QuotationId { get; set; }
        public virtual Quotation Quotation { get; set; } = null!;
        public virtual ICollection<ProposalBilling> ProposalBilling { get; set; } = new HashSet<ProposalBilling>();
    }
}
