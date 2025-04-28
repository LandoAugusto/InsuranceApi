using InsuranceApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceApi.Infra.Data.Mappings
{
    internal class ProductComponentMapping : IEntityTypeConfiguration<ProductComponent>
    {
        public void Configure(EntityTypeBuilder<ProductComponent> builder)
        {
            builder
              .HasKey(x => x.Id);

            builder
            .Property(x => x.Name);

            builder
            .Property(x => x.ProductId);

            builder
            .Property(x => x.CoverageId);

            builder
            .Property(x => x.Code);

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
