namespace InsuranceApi.Core.Models
{
    public class SaveRoleModel
    {
        public int? Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
