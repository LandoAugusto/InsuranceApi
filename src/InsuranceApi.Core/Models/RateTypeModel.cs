namespace InsuranceApi.Core.Models
{
    public class RateTypeModel
    {
        public int RateTypeId { get; set; }
        public required string Name { get; set; }
        public int Code { get; set; }
    }
}
