using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class ProductComponentScreen : IIdentityEntity
    {
        public int Id { get; set; }
        public int ProductComponentId { get; set; }
        public int ComponentId { get; set; }
        public int Order { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual Component Component { get; set; } = null!;
        public virtual ProductComponent ProductComponent { get; set; } = null!;

    }
}
