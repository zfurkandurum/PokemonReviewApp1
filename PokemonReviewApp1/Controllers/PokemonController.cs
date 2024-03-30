using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp1.DTO;
using PokemonReviewApp1.Models;
using PokemonReviewApp1.Interfaces;

namespace PokemonReviewApp1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonController : Controller
{
    private readonly IPokemonRepository _pokemonRepository;
    private readonly IOwnerRepository _ownerRepository;
    private readonly IMapper _mapper;

    public PokemonController(IPokemonRepository pokemonRepository, IOwnerRepository ownerRepository, IMapper mapper)
    {
        _pokemonRepository = pokemonRepository;
        _ownerRepository = ownerRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(200,Type = typeof(IEnumerable<Pokemon>))]
    public IActionResult GetPokemon()
    {
        var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.getPokemons());

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

        var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));

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
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreatePokemon([FromBody] PokemonDto pokemonCreate)
    {
        if (pokemonCreate == null)
            return BadRequest(ModelState);

        var pokemon = _pokemonRepository.getPokemons()
            .Where(p => p.Name.Trim().ToUpper() == pokemonCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();

        if (pokemon != null)
        {
            ModelState.AddModelError("","Already Exists");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pokemonMap = _mapper.Map<Pokemon>(pokemonCreate);
        
        if (!_pokemonRepository.CreatePokemon(pokemonMap))
        {
            ModelState.AddModelError("","error");
            return StatusCode(500, ModelState);
        }

        return Ok("Done");
    }

    [HttpPut("{ownerId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult PokemonUpdate(int pokemonId, [FromQuery] int ownerId,
        [FromQuery] int categoryId, [FromBody] PokemonDto updatedPokemon)
    {
        if (updatedPokemon == null)
            return BadRequest(ModelState);
        
        if (pokemonId != updatedPokemon.Id)
            return BadRequest(ModelState);

        if (!_pokemonRepository.PokemonExists(pokemonId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest();

        var pokemonMap = _mapper.Map<Pokemon>(updatedPokemon);

        if (!_pokemonRepository.UpdatePokemon(ownerId,categoryId,pokemonMap))
        {
            ModelState.AddModelError("","error");
            return StatusCode(500, ModelState);
        }

        return Ok();
    }
}