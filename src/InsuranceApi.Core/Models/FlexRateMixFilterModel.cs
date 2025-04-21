using InsuranceApi.Core.Entities.Enumerators;

namespace InsuranceApi.Core.Models
{
    public class FlexRateMixFilterModel
    {
        public int? BrokerId { get; set; }
        public int? ProductVersionId { get; set; }
        public int? BorrowerId { get; set; }
        public RecordStatusEnum StatusId { get; set; }
    }
}
