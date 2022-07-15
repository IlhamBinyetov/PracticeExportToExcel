using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticeNet.Models;

namespace PracticeNet.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Surname).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.BirthDate).IsRequired(true);
        }
    }
}
