using InsuranceApi.Core.Entities.Enumerators;

namespace InsuranceApi.Core.Entities
{
    public class PersonType
    {
        public int PersonTypeId { get; set; }
        public string Description { get; set; }
        public string Initials { get; set; }
        public string Abbreviation { get; set; }
        public RecordStatusEnum? Status { get; set; }
        public int UserId { get; set; }
        public DateTime DateUtc { get; set; }      
    }
}
