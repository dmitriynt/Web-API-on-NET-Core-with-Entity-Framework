using WebApiApricode.Managers.Contracts;
using WebApiApricode.Data.Contracts.Models.DTO;
using WebApiApricode.Data.Contracts.Models.Entities;
using WebApiApricode.Data.Contracts;
using AutoMapper;

namespace WebApiApricode.Managers.Implementation
{
    internal class GameManager : IGameManager
    {
        private readonly IGameRepository _repository;
        private readonly IMapper _mapper;

        public GameManager(IGameRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> CreateGame(GameAddRequest game)
        {
            var result = await _repository.Add(_mapper.Map<GameEntity>(game));
            return result;
        }

        public async Task<GameResponse> GetGame(Guid id)
        {
            var result = await _repository.GetGame(id);
            return _mapper.Map<GameResponse>(result);
        }

        public async Task<string> EditGame(GameUpdateRequest game)
        {
            string result = String.Empty;
            GameEntity target = await _repository.GetGame(game.Id);
            if (target.Title != String.Empty)
            {
                GameEntity source = _mapper.Map<GameEntity>(game);
                result = await _repository.Update(target, source);
            }
            return result;
        }

        public async Task<string> DeleteGame(Guid id)
        {
            string result = String.Empty;
            GameEntity target = await _repository.GetGame(id);
            if (target.Title != String.Empty)
            {
                result = await _repository.Remove(target);
            }
            return result;
        }

        public async Task<IEnumerable<GameResponse>> GetAllGames()
        {
            var result = from game in await _repository.GetAll()
                         select _mapper.Map<GameResponse>(game);
            return result;
        }

        public IEnumerable<GameResponse> GetGamesToGenres(SearchByGenreRequest genres)
        {
            var target = _mapper.Map<GenresEntity>(genres);
            var result = from game in _repository.GetGamesToGenres(target.Genres)
                         select _mapper.Map<GameResponse>(game);
            return result;
        }
    }
}
