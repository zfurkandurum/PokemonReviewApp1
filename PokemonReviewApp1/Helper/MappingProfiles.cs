using AutoMapper;
using PokemonReviewApp.Models;
using PokemonReviewApp1.Dto;
namespace PokemonReviewApp1.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
       CreateMap<Pokemon, PokemonDto>
    }
}