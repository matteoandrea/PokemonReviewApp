using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data.Mappings;

public class PokemonMap : IEntityTypeConfiguration<Pokemon>
{
    public void Configure(EntityTypeBuilder<Pokemon> builder)
    {
        builder.ToTable("Pokemon");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        builder.HasIndex(x => x.Name, "IX_Pokemon_Name")
            .IsUnique();

        builder.Property(x => x.BirthDate)
            .IsRequired()
            .HasColumnName("BirthDate")
            .HasColumnType("SMALLDATETIME")
            .HasMaxLength(60)
            .HasDefaultValue(DateTime.Now.ToUniversalTime());

        builder.HasMany(x => x.Reviews)
            .WithOne(x => x.Pokemon)
            .HasConstraintName("FK_Pokemon_Review")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.PokemonOwners)
            .WithOne(x => x.Pokemon)
            .HasForeignKey(x => x.PokemonId)
            .HasConstraintName("FK_Pokemon_OwnerId");

        builder.HasMany(x => x.PokemonCategories)
            .WithOne(x => x.Pokemon)
            .HasForeignKey(x => x.PokemonId);
    }
}
