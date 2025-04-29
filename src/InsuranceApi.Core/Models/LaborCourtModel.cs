namespace InsuranceApi.Core.Models
{
    public class LaborCourtModel
    {
        public int LaborCourtId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string AddressNumber { get; set; }
        public string AddressComplement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public int CityId { get; set; }
        public string State { get; set; }
        public int StateId { get; set; }
        public int ZipCode { get; set; }
    }
}
