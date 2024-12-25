using EasyDeals.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyDeals.Data.Configurations;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Products)
            .WithOne(x => x.State)
            .HasForeignKey(x => x.StateId);
    }
}
