using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        builder.HasIndex(x => x.Name, "IX_Category_Name")
           .IsUnique();

        builder.HasMany(x => x.PokemonCategories)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
    }
}
