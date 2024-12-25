using EasyDeals.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyDeals.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);

        // builder
        //    .HasOne(x => x.ParentCategory)
        //    .WithOne(x => x.ParentCategory)
        //    .HasForeignKey<Category>(x => x.ParentCategoryId);

        builder
            .HasMany(x => x.Products)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);

        // ToDO
    }
}