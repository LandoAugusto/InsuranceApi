namespace InsuranceApi.Core.Models
{
    public  class TermTypeModel
    {
        public int TermTypeId { get; set; }
        public string Name { get; set; }
        public string? ExternalCode { get; set; }
        public int TermDays { get; set; }
    }
}
