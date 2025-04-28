using InsuranceApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceApi.Infra.Data.Mappings
{
    internal class FlexRateMapping : IEntityTypeConfiguration<FlexRate>
    {
        public void Configure(EntityTypeBuilder<FlexRate> builder)
        {
            builder
           .HasKey(x => x.FlexRateId);

            builder.Property(e => e.Name)
              .HasMaxLength(100)
              .IsUnicode(false);

            builder.Property(e => e.Description)
              .HasMaxLength(255)
              .IsUnicode(false);

            builder
            .Property(x => x.RateType);

            builder
            .Property(x => x.ProductVersionId);

            builder
            .Property(x => x.RateTypeId);
            
            builder
            .Property(x => x.InsuredAmountValueMin);

            builder
            .Property(x => x.InsuredAmountValueMax);

            builder
            .Property(x => x.RateTypeId);

            builder
            .Property(x => x.IsByValue);
            
            builder
            .Property(x => x.OperationTypeId);
            
            builder
            .Property(x => x.OperationMinValue); 
            
            builder
            .Property(x => x.OperationMaxValue);
            
            builder
            .Property(x => x.ComissionMaxValue);
            
            builder
            .Property(x => x.EffectiveDateStart);
            
            builder
            .Property(x => x.EffectiveDateEnd);
            
            builder
            .Property(x => x.Status);

            builder
            .Property(x => x.InclusionUserId);

            builder
            .Property(x => x.InclusionDate);

            builder
          .Property(x => x.LastChangeDate);

            builder
            .Property(x => x.LastChangeUserId);

        }
    }
}
