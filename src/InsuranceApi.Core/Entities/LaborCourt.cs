using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Core.Entities
{
    public class LaborCourt : IIdentityEntity
    {
        public int LaborCourtId { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? AddressNumber { get; set; }
        public string? AddressComplement { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }        
        public string? State { get; set; }        
        public int ZipCode { get; set; }        
        public int Status { get; set; }
        public string? ExternalCode { get; set; }
        public string? ExternalPersonCode { get; set; }
        public string? ExternalAddressCode { get; set; }
        public int UserId { get; set; }
        public DateTime DateUtc { get; set; }
        public virtual ICollection<CivilCourt> CivilCourt { get; set; } = new HashSet<CivilCourt>();
    }
}
