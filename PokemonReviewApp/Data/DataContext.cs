using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data.Mappings;
using PokemonReviewApp.Models;
using System.Data;

namespace PokemonReviewApp.Data;

public class DataContext : DbContext
{

    public DbSet<PokemonOwner> PokemonOwners { get; private set; }
    public DbSet<PokemonCategory> PokemonCategories { get; private set; }
    public DbSet<Country> Countries { get; private set; }
    public DbSet<Owner> Owners { get; private set; }
    public DbSet<Pokemon> Pokemons { get; private set; }
    public DbSet<Review> Reviews { get; private set; }
    public DbSet<Reviewer> Reviewers { get; private set; }
    public DbSet<Category> Categories { get; private set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=PokemonReview;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=false;TrustServerCertificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PokemonMap());
        modelBuilder.ApplyConfiguration(new ReviewMap());
        modelBuilder.ApplyConfiguration(new ReviewerMap());
        modelBuilder.ApplyConfiguration(new PokemonOwnerMap());
        modelBuilder.ApplyConfiguration(new PokemonCategoryMap());
        modelBuilder.ApplyConfiguration(new CountryMap());
        modelBuilder.ApplyConfiguration(new OwnerMap());
        modelBuilder.ApplyConfiguration(new CategoryMap());

    }
}
