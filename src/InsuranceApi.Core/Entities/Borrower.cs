using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class Borrower : IIdentityEntity
    {
        public int BorrowerId { get; set; }
        public long PersonId { get; set; }
        public int BorrowerExternalId { get; set; }
        public virtual Person Person { get; set; } = null!;
        public virtual ICollection<BorrowerAppealFee> BorrowerAppealFee { get; set; } = new HashSet<BorrowerAppealFee>();
    }
}
