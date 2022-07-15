using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticeNet.Models;

namespace PracticeNet.Data.Configurations
{
    public class CityConfiguration: IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired(true);
        }
    }
}
