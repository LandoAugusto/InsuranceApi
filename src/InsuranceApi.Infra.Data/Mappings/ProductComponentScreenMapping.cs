using InsuranceApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceApi.Infra.Data.Mappings
{
    internal class ProductComponentScreenMapping : IEntityTypeConfiguration<ProductComponentScreen>
    {
        public void Configure(EntityTypeBuilder<ProductComponentScreen> builder)
        {
            builder
              .HasKey(x => x.Id);

            builder
            .Property(x => x.ProductComponent);

            builder
            .Property(x => x.Component);

            builder
            .Property(x => x.Order);

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
