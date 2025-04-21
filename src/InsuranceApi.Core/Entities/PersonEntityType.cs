using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public  class PersonEntityType : IIdentityEntity
    {
        public long PersonEntityTypeId { get; set; }
        public long PersonId { get; set; }
        public int EntityTypeId { get; set; }
        public RecordStatusEnum? Status { get; set; }
        public int UserId { get; set; }
        public DateTime DateUtc { get; set; }
        public virtual Person Person { get; set; } = null!;
        public virtual EntityType EntityType { get; set; } = null!;

    }
}
