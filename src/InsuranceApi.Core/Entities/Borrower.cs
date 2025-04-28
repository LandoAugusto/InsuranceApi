using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class Borrower : IIdentityEntity
    {
        public int BorrowerId { get; set; }
        public int PersonId { get; set; }
        public int BrokerId { get; set; }
        public int EconomicGroupId { get; set; }
        public string? LegacyCode { get; set; }
        public string? AddressLegacyCode { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual Person Person { get; set; } = null!;
        public virtual ICollection<BorrowerAppealFee> BorrowerAppealFee { get; set; } = new HashSet<BorrowerAppealFee>();
    }
}
