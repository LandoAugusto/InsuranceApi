namespace InsuranceApi.Core.Models
{
    public class OperationTypeModel
    {
        public int OperationTypeId { get; set; }
        public required string Name { get; set; }
        public int Code { get; set; }
    }
}
