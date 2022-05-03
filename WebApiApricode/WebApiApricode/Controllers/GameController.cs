using Microsoft.AspNetCore.Mvc;
using WebApiApricode.Managers.Contracts;
using WebApiApricode.Data.Contracts.Models.DTO;

namespace WebApiApricode.Controllers
{
    /// <summary>
    /// Контроллер для работы с информацией об играх
    /// </summary>
    [Route("games/")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameManager _gameService;

        /// <summary>
        /// Конструктор
        /// </summary>
        public GameController(IGameManager gameService)
        {
            _gameService = gameService;
        }

        /// <summary>
        /// Получить список всех игр
        /// </summary>
        /// <returns>Список игр</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _gameService.GetAllGames();
            return Ok(result);
        }

        /// <summary>
        /// Получить информацию об игре
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(Guid id)
        {
            var result = await _gameService.GetGame(id);
            if(result.Title == String.Empty) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Получить список всех игр указанного жанра
        /// </summary>
        /// <returns>Список игр</returns>
        [HttpPost("genres/")]
        public IActionResult GetGameToGenre([FromBody] SearchByGenreRequest genre)
        {
            var result = _gameService.GetGamesToGenres(genre);
            return Ok(result);
        }

        /// <summary>
        /// Добавить информацию об игре
        /// </summary>
        [HttpPost("create/")]
        public async Task<IActionResult> CreateGame([FromBody] GameAddRequest game)
        {
            var result = await _gameService.CreateGame(game);
            return Ok(result);
        }

        /// <summary>
        /// Редактировать информацию об игре
        /// </summary>
        [HttpPut("edit/")]
        public async Task<IActionResult> EditGame([FromBody] GameUpdateRequest game)
        {
            var result = await _gameService.EditGame(game);
            if(result == String.Empty) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Удалить информацию об игре
        /// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            var result = await _gameService.DeleteGame(id);
            if (result == String.Empty) return NotFound();
            return Ok(result);
        }
    }
}
