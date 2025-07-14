
using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class Person : IIdentityEntity
    {
        public int PersonId { get; set; }        
        public int DocumentTypeId { get; set; }
        public string? Document { get; set; }
        public string Name { get; set; }
        public string? IssuingBody { get; set; }
        public int? GenderId { get; set; }
        public DateTime? BornDate { get; set; }
        public string? MaritalStatusId { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual DocumentType DocumentType { get; set; } = null!;
        public virtual ICollection<Address> Address { get; set; } = new HashSet<Address>();
        public virtual ICollection<Broker> Broker { get; set; } = new HashSet<Broker>();
        public virtual ICollection<Borrower> Borrower { get; set; } = new HashSet<Borrower>();        
    }
}
