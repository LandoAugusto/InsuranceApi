namespace InsuranceApi.Core.Models
{
    public class UpdatePasswordUserModel
    {
        public int? Id { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
