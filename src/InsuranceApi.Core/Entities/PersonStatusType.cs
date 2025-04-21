using InsuranceApi.Core.Entities.Enumerators;

namespace InsuranceApi.Core.Entities
{
    public class PersonStatusType
    {
        public int PersonStatusTypeId { get; set; }
        public string Description { get; set; }
        public string Initials { get; set; }
        public RecordStatusEnum? Status { get; set; }
        public int UserId { get; set; }
        public DateTime DateUtc { get; set; }
        public virtual ICollection<Person> Person { get; set; } = new HashSet<Person>();        
    }
}
