using InsuranceApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceApi.Infra.Data.Mappings
{
    internal class LaborCourtMapping : IEntityTypeConfiguration<LaborCourt>
    {
        public void Configure(EntityTypeBuilder<LaborCourt> builder)
        {
            builder
              .HasKey(x => x.LaborCourtId);

            builder.Property(e => e.Name)
              .HasMaxLength(100)
              .IsUnicode(false);

            builder.Property(e => e.Name)
              .HasMaxLength(255)
              .IsUnicode(false);

            builder
            .Property(x => x.Status);

            builder
            .Property(x => x.UserId);

            builder
            .Property(x => x.DateUtc);
        }
    }
}
