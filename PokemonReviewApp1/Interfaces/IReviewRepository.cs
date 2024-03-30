using PokemonReviewApp1.Models;

namespace PokemonReviewApp1.Interfaces;

public interface IReviewRepository
{
    ICollection<Review> GetReviews();

    Review GetReview(int id);

    ICollection<Review> GetReviewsOfAPokemon(int pokemonId);

    bool ReviewExists(int reviewId);

    bool CreateReview(Review review);

    bool Save();
}