using InsuranceApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceApi.Infra.Data.Mappings
{
    internal class InsuredTypeMapping : IEntityTypeConfiguration<InsuredType>
    {
        public void Configure(EntityTypeBuilder<InsuredType> builder)
        {

            builder
          .HasKey(x => x.InsuredTypeId);

            builder.Property(e => e.Name)
              .HasMaxLength(100)
              .IsUnicode(false);

            builder
            .Property(x => x.Status);

            builder
           .Property(x => x.Status);

            builder
            .Property(x => x.InclusionUserId);

            builder
            .Property(x => x.LastChangeDate);

            builder
            .Property(x => x.LastChangeUserId);

            builder
            .Property(x => x.LastChangeDate);
        }
    }
}
