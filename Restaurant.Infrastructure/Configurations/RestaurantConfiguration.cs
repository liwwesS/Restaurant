using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Configurations;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurants>
{
    public void Configure(EntityTypeBuilder<Restaurants> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder
            .HasMany(r => r.MenuItems)
            .WithOne()
            .HasForeignKey(r => r.RestaurantId);
    }
}