using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp1.Data;
using PokemonReviewApp1.Interfaces;
using PokemonReviewApp1.Models;

namespace PokemonReviewApp1.Repository;

public class CountryRepository : ICountryRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CountryRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public ICollection<Country> GetCountries()
    {
        return _context.Countries.ToList();
    }

    public Country GetCountry(int id)
    {
        return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
    }

    public Country GetCountryByOwner(int ownerId)
    {
        return _context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
    }

    public ICollection<Owner> GetOwnerFromCountry(int countryId)
    {
        return _context.Owners.Where(o => o.Country.Id == countryId).ToList();
    }

    public bool CountryExits(int id)
    {
        return _context.Countries.Any(c => c.Id == id);
    }

    public bool CreateCountry(Country country)
    {
        _context.Add(country);
        return Save();
    }

    public bool UpdateCountry(Country country)
    {
        _context.Update(country);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}