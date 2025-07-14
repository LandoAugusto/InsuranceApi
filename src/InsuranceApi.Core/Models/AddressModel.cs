namespace InsuranceApi.Core.Models
{
    public class AddressModel
    {
        public int AddressId { get; set; }
        public int PersonId { get; set; }
        public bool IsMainAddress { get; set; }
        public int AddressTypeId { get; set; }
        public int ZipCode { get; set; }
        public string StreetName { get; set; }
        public required string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
    }
}
