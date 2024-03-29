using PokemonReviewApp1.Models;

namespace PokemonReviewApp1.Interfaces;

public interface IPokemonRepository
{
    ICollection<Pokemon> getPokemons();

    Pokemon GetPokemon(int id);
    Pokemon getPokemon(string name);

    decimal GetPokemonRating(int pokeId);

    bool PokemonExists(int pokeId);

    bool CreatePokemon(Pokemon pokemon);
    bool Save();
}