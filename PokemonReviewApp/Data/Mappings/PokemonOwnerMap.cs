using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data.Mappings
{
    public class PokemonOwnerMap : IEntityTypeConfiguration<PokemonOwner>
    {
        public void Configure(EntityTypeBuilder<PokemonOwner> builder)
        {
            builder.ToTable("PokemonOwner");

            builder.HasKey(x => new { x.PokemonId, x.OwnerId });

            builder.HasOne(x => x.Pokemon)
                .WithMany(x => x.PokemonOwners)
                .HasForeignKey(x => x.PokemonId);

            builder.HasOne(x => x.Owner)
                .WithMany(x => x.PokemonOwners)
                .HasForeignKey(x => x.OwnerId);
        }
    }

}
