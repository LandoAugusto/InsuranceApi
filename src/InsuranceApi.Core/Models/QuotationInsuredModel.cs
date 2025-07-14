namespace InsuranceApi.Core.Models
{
    public class QuotationInsuredModel
    {
        public int? PersonId { get; set; }
        public int DocumentTypeId { get; set; }
        public string? Document { get; set; }
        public string Name { get; set; }
        public string? IssuingBody { get; set; }
        public int? GenderId { get; set; }
        public DateTime? BornDate { get; set; }
        public string? MaritalStatusId { get; set; }
        public required AddressModel Address { get; set; }
    }
}
