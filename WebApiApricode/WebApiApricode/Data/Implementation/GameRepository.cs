using WebApiApricode.Data.Contracts;
using WebApiApricode.Data.Contracts.Models.Entities;
using WebApiApricode.Data.Ef;
using Microsoft.EntityFrameworkCore;

namespace WebApiApricode.Data.Implementation
{
    internal class GameRepository : IGameRepository
    {
        private readonly WebApiApricodeDbContext _context;

        public GameRepository(WebApiApricodeDbContext context)
        {
            _context = context;
        }

        public async Task<string> Add(GameEntity game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game.Id.ToString();
        }

        public async Task<IEnumerable<GameEntity>> GetAll()
        {
            var result = await _context.Games
                .AsNoTracking()
                .ToListAsync();
            return result;
        }

        public async Task<GameEntity> GetGame(Guid id)
        {
            var result = await _context.Games
                .Where(g => g.Id == id)
                .FirstOrDefaultAsync();
            return result == null ? new GameEntity() { Title = String.Empty } : result;
        }

        public List<GameEntity> GetGamesByGenres(List<GenreEnum> genres)
        {
            IQueryable<GameEntity> result = _context.Games;
            foreach(var genre in genres)
            {
                result = result.Where(g => g.Genres.Contains(genre));
            }
            return result.ToList();
        }

        public async Task<string> Remove(GameEntity game)
        {
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return game.Id.ToString();
        }

        public async Task<string> Update(GameEntity target, GameEntity source)
        {
            target.Title = source.Title;
            target.Developer = source.Developer;
            target.Genres = source.Genres;
            await _context.SaveChangesAsync();
            return target.Id.ToString();
        }
    }
}