namespace InsuranceApi.Core.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<int>? MenuIds { get; set; } = [];
    }
}
