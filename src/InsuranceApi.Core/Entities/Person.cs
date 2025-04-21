using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class Person : IIdentityEntity
    {
        public long PersonId { get; set; }
        public int PersonTypeId { get; set; }       
        public int DocumentTypeId { get; set; }
        public string? Document { get; set; }
        public string Name { get; set; }
        public string? IssuingBody { get; set; }
        public int? GenderId { get; set; }
        public DateTime? BornDate { get; set; }
        public string? MaritalStatusId { get; set; }
        public int   Status { get; set; }                        
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual PersonType PersonType { get; set; } = null!;
        
        //Foreing key
        public virtual ICollection<Broker> Broker { get; set; } = new HashSet<Broker>();
        public virtual ICollection<Borrower> Borrower { get; set; } = new HashSet<Borrower>();
        public virtual ICollection<PersonEntityType> PersonEntityType { get; set; } = new HashSet<PersonEntityType>();
    }
}
