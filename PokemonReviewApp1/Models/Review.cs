namespace PokemonReviewApp1.Models;

public class Review
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public double Rating { get; set; }

    public Pokemon Pokemon { get; set; }
    public Reviewer Reviewer { get; set; }
}