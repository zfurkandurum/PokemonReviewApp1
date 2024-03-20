using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Models;
using PokemonReviewApp1.Data;
using PokemonReviewApp1.Interfaces;

namespace PokemonReviewApp1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonController : Controller
{
    private readonly IPokemonRepository _pokemonRepository;
    public PokemonController(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }
    
    [HttpGet]
    [ProducesResponseType(200,Type = typeof(IEnumerable<Pokemon>))]
    public IActionResult GetPokemon()
    {
        var pokemons = _pokemonRepository.getPokemons();

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(pokemons);
    }
    
    [HttpGet("{pokeId}")]
    [ProducesResponseType(200,Type = typeof(Pokemon))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemon(int pokeId)
    {
        if (!_pokemonRepository.PokemonExists(pokeId))
        {
            return NotFound();
        }

        var pokemon = _pokemonRepository.GetPokemon(pokeId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(pokemon);
    }
    
    [HttpGet("{pokeId}/rating")]
    [ProducesResponseType(200,Type = typeof(decimal))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemonRating(int pokeId)
    {
        if (!_pokemonRepository.PokemonExists(pokeId))
        {
            return NotFound();
        }

        var rating = _pokemonRepository.GetPokemon(pokeId);

        if (!ModelState.IsValid)
            return BadRequest();

        return Ok(rating);
    }
}