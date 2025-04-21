using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class EntityType:  IIdentityEntity
    {
        public int EntityTypeId { get; set; }
        public string Name { get; set; }
        public string? CssImage { get; set; }
        public RecordStatusEnum? Status { get; set; }
        public int UserId { get; set; }
        public DateTime DateUtc { get; set; }
        public bool IsLocked { get; set; }
        public virtual ICollection<PersonEntityType> PersonEntityType { get; set; } = new HashSet<PersonEntityType>();
    }
}
