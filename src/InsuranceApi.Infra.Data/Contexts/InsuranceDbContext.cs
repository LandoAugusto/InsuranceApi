using InsuranceApi.Api.Core.Entities;
using InsuranceApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApi.Infra.Data.Contexts
{
    internal class InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
       
        public virtual DbSet<Quotation> Quotation { get; set; }
        public virtual DbSet<QuotationAutoItem> QuotationAutoItem { get; set; }
        public virtual DbSet<QuotationItem> QuotationItem { get; set; }
        public virtual DbSet<QuotationCoverage> QuotationCoverage { get; set; }
        public virtual DbSet<QuotationCoverageFranchise> QuotationCoverageFranchise { get; set; }
        //public virtual DbSet<QuotationFlexMixRate> QuotationFlexMixRate { get; set; }
        public virtual DbSet<QuotationQuestionnaireItem> QuotationQuestionnaireItem { get; set; }
        public virtual DbSet<QuotationRiskLocationItem> QuotationRiskLocationItem { get; set; }
        public virtual DbSet<QuotationWarranty> QuotationWarranty { get; set; }
        public virtual DbSet<QuotationWarrantyComplement> QuotationWarrantyComplement { get; set; }
        public virtual DbSet<QuotationWarrantyClaimant> QuotationWarrantyClaimant { get; set; }        
        public virtual DbSet<QuotationWarrantyLegalRecourse> QuotationWarrantyLegalRecourse { get; set; }
        public virtual DbSet<Borrower> Borrower { get; set; }
        public virtual DbSet<BorrowerAppealFee> BorrowerAppealFee { get; set; }
        public virtual DbSet<Broker> Broker { get; set; }
        public virtual DbSet<EntityType> EntityType { get; set; }
        public virtual DbSet<FlexRate> FlexRate { get; set; }
        public virtual DbSet<FlexRateBorrower> FlexRateBorrower { get; set; }
        public virtual DbSet<FlexRateBroker> FlexRateBroker { get; set; }
        public virtual DbSet<FlexRateProfile> FlexRateProfile { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonType> PersonType { get; set; }
        public virtual DbSet<Core.Entities.Component> Component { get; set; }
        public virtual DbSet<ProductComponent> ProductComponent { get; set; }
        public virtual DbSet<ProductComponentScreen> ProductComponentScreen { get; set; }

    }
}
