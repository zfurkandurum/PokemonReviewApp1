using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;
using PokemonReviewApp1.Data;
using PokemonReviewApp1.Interfaces;

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
}