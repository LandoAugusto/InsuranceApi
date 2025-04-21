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
    }
}
