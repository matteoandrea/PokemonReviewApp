using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data.Mappings;

public class PokemonCategoryMap : IEntityTypeConfiguration<PokemonCategory>
{
    public void Configure(EntityTypeBuilder<PokemonCategory> builder)
    {
        builder.ToTable("PokemonCategory");

        builder.HasKey(x => new { x.PokemonId, x.CategoryId });

        builder.HasOne(x => x.Pokemon)
            .WithMany(x => x.PokemonCategories)
            .HasForeignKey(x => x.PokemonId);

        builder.HasOne(x => x.Category)
           .WithMany(x => x.PokemonCategories)
           .HasForeignKey(x => x.CategoryId);
    }
}
