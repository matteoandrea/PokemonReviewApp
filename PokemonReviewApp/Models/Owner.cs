using PokemonReviewApp.Models.Core;

namespace PokemonReviewApp.Models;

public class Owner : Model
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gym { get; set; }
    public Country Country { get; set; }
    public ICollection<PokemonOwner> PokemonOwners { get; set; }
}
