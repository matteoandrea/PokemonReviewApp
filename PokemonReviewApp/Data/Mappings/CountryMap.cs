using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data.Mappings;

public class CountryMap : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Country");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        builder.HasIndex(x => x.Name, "IX_Country_Name")
           .IsUnique();

        builder.HasMany(x => x.Owners)
            .WithOne(x => x.Country);

    }
}
