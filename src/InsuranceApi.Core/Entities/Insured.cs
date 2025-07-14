namespace InsuranceApi.Core.Entities
{
    public class QuotationInsured
    {
        public long QuotationId { get; set; }
        public long PersonId { get; set; }
        public required string Document { get; set; }
        public required string Name { get; set; }
        public int AddressTypeId { get; set; }
        public int ZipCode { get; set; }
        public required string StreetName { get; set; }
        public required string Number { get; set; }
        public string? Complement { get; set; }
        public required string District { get; set; }
        public int CityId { get; set; }
        public bool IsMainAddress { get; set; }

    }
}
