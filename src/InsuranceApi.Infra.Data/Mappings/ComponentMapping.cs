using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceApi.Infra.Data.Mappings
{
    internal class ComponentMapping : IEntityTypeConfiguration<Core.Entities.Component>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Component> builder)
        {
            builder
            .HasKey(x => x.Id);

            builder
            .Property(x => x.Name);

            builder
            .Property(x => x.Description);

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