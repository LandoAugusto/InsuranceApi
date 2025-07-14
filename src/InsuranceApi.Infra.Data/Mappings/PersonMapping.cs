using InsuranceApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceApi.Infra.Data.Mappings
{
    internal class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
              .HasKey(x => x.PersonId);

            builder.Property(e => e.Name)
           .HasMaxLength(100)
           .IsUnicode(false);

            builder
            .Property(x => x.Document);

            builder
           .Property(x => x.DocumentTypeId);

            builder
            .Property(x => x.BornDate);

            builder
            .Property(x => x.GenderId);

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
