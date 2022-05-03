using AutoMapper;
using WebApiApricode.Data.Contracts.Models.DTO;
using WebApiApricode.Data.Contracts.Models.Entities;

namespace WebApiApricode.Services
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GameEntity, GameResponse>()
                .ForMember(
                dest => dest.Genres, 
                act => act.MapFrom(ol => ol.Genres.Select(e => e.ToString()))); ;
            CreateMap<GameAddRequest, GameEntity>()
                .ForMember(
                dest => dest.Id,
                act => Guid.NewGuid());
            CreateMap<GameUpdateRequest, GameEntity>();
            CreateMap<SearchByGenreRequest, GenresEntity>();
        }
    }
}
