using InsuranceApi.Core.Entities.Enumerators;

namespace InsuranceApi.Core.Models
{
    public class PersonModelRequest
    {
        public int PersonType { get; set; }
        public DocumentTypeEnum DocumentType { get; set; }
        public int Name { get; set; }
        public required IEnumerable<PersonAddressModelRequest> Address { get; set; }
    }
}
