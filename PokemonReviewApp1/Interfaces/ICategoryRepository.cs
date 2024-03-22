using PokemonReviewApp1.Models;

namespace PokemonReviewApp1.Interfaces;

public interface ICategoryRepository
{
    ICollection<Category> GetCategories();

    Category GetCategory(int id);
    ICollection<Pokemon> GetPokemonByCategory(int categotyId);
    bool CategoryExits(int id);
}