using PokemonReviewApp.Models.Core;

namespace PokemonReviewApp.Models;

public class Review : Model
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public Reviewer Reviewer { get; set; }
    public Pokemon Pokemon { get; set; }
}
