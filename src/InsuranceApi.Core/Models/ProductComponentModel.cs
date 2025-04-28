namespace InsuranceApi.Core.Models
{
    public class ProductComponentModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CoverageId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
    }
}
