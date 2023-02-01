using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data.Mappings;

public class OwnerMap : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.ToTable("Owner");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        builder.HasIndex(x => x.Name, "IX_Owner_Name")
           .IsUnique();

        builder.Property(x => x.Gym)
         .IsRequired()
         .HasColumnName("Gym")
         .HasColumnType("NVARCHAR")
         .HasMaxLength(80);

        builder.HasOne(x => x.Country)
            .WithMany(x => x.Owners)
            .HasConstraintName("FK_Owner_Country")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.PokemonOwners)
            .WithOne(x => x.Owner)
            .HasForeignKey(x => x.OwnerId)
            .HasConstraintName("FK_Owner_PokemonId");


    }
}
