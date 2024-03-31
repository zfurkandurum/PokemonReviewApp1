using Microsoft.EntityFrameworkCore;
using PokemonReviewApp1.Data;
using PokemonReviewApp1.Interfaces;
using PokemonReviewApp1.Models;

namespace PokemonReviewApp1.Repository;

public class PokemonRepository : IPokemonRepository
{
    private readonly DataContext _context;

    public PokemonRepository(DataContext context)
    {
        _context = context;
    }
    
    public ICollection<Pokemon> getPokemons()
    {
        return  _context.Pokemons.OrderBy(p => p.Id).ToList();
    }

    public Pokemon GetPokemon(int id)
    {
        return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
    }
 
    public Pokemon getPokemon(string name)
    {
        return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
    }

    public decimal GetPokemonRating(int pokeId)
    {
        var review = _context.Reviews.Where(r => r.Id == pokeId);

        if (review.Count()==0)
        {
            return 0;
        }

        return ((decimal)review.Sum(r => r.Rating) / review.Count());
    }

    public bool PokemonExists(int pokeId)
    {
        return _context.Pokemons.Any(p => p.Id == pokeId); 
    }

    public bool CreatePokemon(Pokemon pokemon)
    {
        _context.Pokemons.Add(pokemon);
        return Save();
    }

    public bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon)
    {
        _context.Update(pokemon);
        return Save();
    }

    public bool DeletePokemon(Pokemon pokemon)
    {
        _context.Remove(pokemon);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}