namespace InsuranceApi.Core.Models
{
    public class PersonAddressModelRequest
    {
        public string? ZipCode { get; set; }
        public string? StreetName { get; set; }
        public string? Complement { get; set; }
        public string? District { get; set; }
        public string State { get; set; }
        public string StateUf { get; set; }
        public string City { get; set; }
    }
}
