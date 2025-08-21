namespace InsuranceApi.Core.Models
{
    public class UpdateUserModel
    {
        public string? Id { get; set; }
        public int RoleId { get; set; }
        public string? Email { get; set; }
    }
}
