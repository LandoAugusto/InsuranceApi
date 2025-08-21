namespace InsuranceApi.Core.Models
{
    public class UseModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public IEnumerable<RoleModel> Roles { get; set; } = new List<RoleModel>();  
    }
}
