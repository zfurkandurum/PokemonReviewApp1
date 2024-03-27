using PokemonReviewApp1.Data;
using PokemonReviewApp1.Interfaces;
using PokemonReviewApp1.Models;

namespace PokemonReviewApp1.Repository;

public class CategoryRepository : ICategoryRepository
{

    private DataContext _context;

    public CategoryRepository(DataContext context)
    {
        _context = context; 
    }
    public ICollection<Category> GetCategories()
    {
        return _context.Categories.ToList();
    }

    public Category GetCategory(int id)
    {
        return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
    }

    public ICollection<Pokemon> GetPokemonByCategory(int categotyId)
    {
        return _context.PokemonCategories.Where(pc => pc.CategoryId == categotyId).Select(p => p.Pokemon).ToList();
    }

    public bool CategoryExits(int id)
    {
        return _context.Categories.Any(c => c.Id == id);
    }

    public bool CreateCategory(Category category)
    {
        _context.Add(category);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}