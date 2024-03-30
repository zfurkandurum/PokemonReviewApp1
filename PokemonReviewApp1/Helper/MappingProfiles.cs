using AutoMapper;
using PokemonReviewApp1.DTO;
using PokemonReviewApp1.Models;

namespace PokemonReviewApp1.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pokemon, PokemonDto >();
        CreateMap<Category, CategoryDto >();
        CreateMap<Country, CountryDto >();
        CreateMap<Owner, OwnerDto >();
        CreateMap<Review, ReviewDto >();
        CreateMap<Reviewer, ReviewerDto >();

        CreateMap<CategoryDto, Category >();
        CreateMap<CountryDto, Country >();
        CreateMap<OwnerDto, Owner >();
        CreateMap<PokemonDto, Pokemon>();
        CreateMap<ReviewDto, Review >();
        CreateMap<ReviewerDto, Reviewer >();
    }
}