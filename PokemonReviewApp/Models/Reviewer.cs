using PokemonReviewApp.Models.Core;

namespace PokemonReviewApp.Models;

public class Reviewer : Model
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Review> Reviews { get; set; }
}
