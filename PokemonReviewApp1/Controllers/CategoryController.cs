using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp1.DTO;
using PokemonReviewApp1.Interfaces;
using PokemonReviewApp1.Models;

namespace PokemonReviewApp1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(200,Type = typeof(IEnumerable<Pokemon>))]
    public IActionResult GetCategory()
    {
        var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(categories);
    }
    
    [HttpGet("{categoryId}")]
    [ProducesResponseType(200,Type = typeof(Pokemon))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemon(int categoryId)
    {
        if (!_categoryRepository.CategoryExits(categoryId))
        {
            return NotFound();
        }

        var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(categoryId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(category);
    }
    
    [HttpGet("pokemon/{categoryId}")]
    [ProducesResponseType(200,Type = typeof(IEnumerable<Category>))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemonByCategoryId(int categoryId)
    {
        var categories = _mapper.Map<List<PokemonDto>>(_categoryRepository.GetPokemonByCategory(categoryId));

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(categories);
    }
}