using PokemonReviewApp.Models;

namespace PokemonReviewApp1.Interfaces;

public interface IPokemonRepository
{
    ICollection<Pokemon> getPokemons();
}