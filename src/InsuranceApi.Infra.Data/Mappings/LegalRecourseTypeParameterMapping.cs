using InsuranceApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceApi.Infra.Data.Mappings
{
    public class LegalRecourseTypeParameterMapping : IEntityTypeConfiguration<LegalRecourseTypeParameter>
    {
        public void Configure(EntityTypeBuilder<LegalRecourseTypeParameter> builder)
        {
            builder
              .HasKey(x => x.LegalRecourseTypeParameterId);

            builder
           .Property(x => x.LegalRecourseTypeId);

            builder
            .Property(x => x.StartCoverage);

            builder
            .Property(x => x.EndCoverage);
      

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

