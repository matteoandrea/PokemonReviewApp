using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data.Mappings;

public class ReviewMap : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Review");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnName("Title")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Text)
         .IsRequired()
         .HasColumnName("Text")
         .HasColumnType("TEXT")
         .HasMaxLength(255);

        builder.HasOne(x => x.Reviewer)
            .WithMany(x => x.Reviews)
            .HasConstraintName("FK_Review_Reviwer")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x=>x.Pokemon)
            .WithMany(x=>x.Reviews)
            .HasConstraintName("FK_Review_Pokemon")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
