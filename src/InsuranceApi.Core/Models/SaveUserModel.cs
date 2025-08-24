namespace InsuranceApi.Core.Models
{
    public class SaveUserModel
    {
        public int RoleId { get; set; }
        public int ProfileId { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
