using PokemonReviewApp1.Models;

namespace PokemonReviewApp1.Interfaces;

public interface ICountryRepository
{
    ICollection<Country> GetCountries();

    Country GetCountry(int id);
    Country GetCountryByOwner(int ownerId);

    ICollection<Owner> GetOwnerFromCountry(int countryId);

    bool CountryExits(int id);

    bool CreateCountry(Country country);
    bool Save();
}