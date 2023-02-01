using PokemonReviewApp.Models.Core;

namespace PokemonReviewApp.Models;

public class Country : Model
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Owner> Owners { get; set; }
}
