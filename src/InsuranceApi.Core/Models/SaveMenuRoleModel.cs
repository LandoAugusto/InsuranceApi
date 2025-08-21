namespace InsuranceApi.Core.Models
{
    public class SaveMenuRoleModel
    {
        public required string RoleName { get; set; }
        public List<int> MenuIds { get; set; } = [];
    }
}
