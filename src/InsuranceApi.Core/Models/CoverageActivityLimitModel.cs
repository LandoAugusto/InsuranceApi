namespace InsuranceApi.Core.Models
{
    public  class CoverageActivityLimitModel
    {   
        public decimal InsuredAmountMin { get; set; }
        public decimal InsuredAmountMax { get; set; }
        public decimal PercenteSubLimitBasic { get; set; }
        public decimal PercenteSubLimit { get; set; }
        public decimal PercenteLimitMin { get; set; }
        public decimal PercenteLimitMax { get; set; }
        public decimal PercenteLimitUF { get; set; }
    }
}
