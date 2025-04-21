using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class Person : IIdentityEntity
    {
        public long PersonId { get; set; }
        public int PersonTypeId { get; set; }
        public string Name { get; set; }
        public string? Document { get; set; }
        public string? FormattedDocument { get; set; }
        public string? DocumentCity { get; set; }
        public string? FantasyName { get; set; }
        public string?   Activity { get; set; }
        public DateTime ? BornDate { get; set; }
        public string? Observation { get; set; }
        public int? GenderId { get; set; }
        public int PersonStatusTypeId { get; set; }
        public int UserId { get; set; }
        public DateTime DateUtc { get; set; }

        public virtual PersonType PersonType { get; set; } = null!;
        public virtual PersonStatusType PersonStatusType { get; set; } = null!;

        //Foreing key
        public virtual ICollection<Broker> Broker { get; set; } = new HashSet<Broker>();
        public virtual ICollection<Borrower> Borrower { get; set; } = new HashSet<Borrower>();
        public virtual ICollection<PersonEntityType> PersonEntityType { get; set; } = new HashSet<PersonEntityType>();
    }
}
