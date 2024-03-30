using PokemonReviewApp1.Models;

namespace PokemonReviewApp1.Interfaces;

public interface IReviewerRepository
{
    ICollection<Reviewer> GetReviewers();

    Reviewer GetReviewer(int id);

    ICollection<Review> GetReviewsByReviewer(int reviewerId);
    
    bool ReviewerExists(int reviewerId);

    bool CreateReviewer(Reviewer reviewer);

    bool Save();

}