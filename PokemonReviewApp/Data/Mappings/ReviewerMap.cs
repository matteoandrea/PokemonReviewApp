using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data.Mappings;

public class ReviewerMap : IEntityTypeConfiguration<Reviewer>
{
    public void Configure(EntityTypeBuilder<Reviewer> builder)
    {
        builder.ToTable("Reviewer");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasColumnName("FirstName")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.LastName)
         .IsRequired()
         .HasColumnName("LastName")
         .HasColumnType("NVARCHAR")
         .HasMaxLength(80);

        builder.HasMany(x => x.Reviews)
            .WithOne(x => x.Reviewer)
            .HasConstraintName("FK_Reviewer_Review")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
