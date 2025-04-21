using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Api.Core.Entities
{
    public class FlexRateProfile : IIdentityEntity
    {
        public int? FlexRateProfileId { get; set; }
        public int? FlexRateId { get; set; }
        public int? ProfileId { get; set; }
        public RecordStatusEnum? Status { get; set; }
        public int? UserId { get; set; }
        public DateTime DateUtc { get; set; }
    }
}