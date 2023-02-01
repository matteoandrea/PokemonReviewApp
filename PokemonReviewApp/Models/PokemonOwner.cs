using PokemonReviewApp.Models.Core;

namespace PokemonReviewApp.Models;

public class PokemonOwner : Model
{
    public int PokemonId { get; set; }
    public int OwnerId { get; set; }
    public Pokemon Pokemon { get; set; }
    public Owner Owner { get; set; }
}
