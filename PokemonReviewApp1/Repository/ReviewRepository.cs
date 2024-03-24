using AutoMapper;
using PokemonReviewApp1.Data;
using PokemonReviewApp1.Interfaces;
using PokemonReviewApp1.Models;

namespace PokemonReviewApp1.Repository;

public class ReviewRepository : IReviewRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ReviewRepository(DataContext dataContext, IMapper mapper)
    {
        _mapper = mapper;
        _context = dataContext;
    }
    public ICollection<Review> GetReviews()
    {
        return _context.Reviews.ToList();
    }

    public Review GetReview(int id)
    {
        return _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
    }

    public ICollection<Review> GetReviewsOfAPokemon(int pokemonId)
    {
        return _context.Reviews.Where(r => r.Id == pokemonId).ToList();
    }

    public bool ReviewExists(int reviewId)
    {
        return _context.Reviews.Any(r => r.Id == reviewId);
    }
}