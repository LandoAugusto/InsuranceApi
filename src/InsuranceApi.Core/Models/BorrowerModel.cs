namespace InsuranceApi.Core.Models
{
    public class BorrowerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal AvailableLimit { get; set; }
    }
}
