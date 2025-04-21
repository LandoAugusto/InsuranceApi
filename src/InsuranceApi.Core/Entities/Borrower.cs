using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class Borrower : IIdentityEntity
    {
        public int TakerId { get; set; }
        public long PersonId { get; set; }
        public int TakerExternalId { get; set; }
        public virtual Person Person { get; set; } = null!;
        public virtual ICollection<BorrowerAppealFee> TakerAppealFee { get; set; } = new HashSet<BorrowerAppealFee>();
    }
}
