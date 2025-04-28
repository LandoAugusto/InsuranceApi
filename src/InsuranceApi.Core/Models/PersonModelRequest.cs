using InsuranceApi.Core.Entities.Enumerators;

namespace InsuranceApi.Core.Models
{
    public class PersonModelRequest
    {
        public int PersonType { get; set; }
        public DocumentTypeEnum DocumentType { get; set; }
        public string Document { get; set; }
        public int Name { get; set; }
        public bool IsMain { get; set; }
        public required IEnumerable<PersonAddressModelRequest> Address { get; set; }
    }
}
