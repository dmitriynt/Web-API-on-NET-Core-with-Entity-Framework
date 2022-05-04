using WebApiApricode.Data.Contracts.Models.DTO;

namespace WebApiApricode.Managers.Contracts
{
    /// <summary>
    /// Описание методов менеджера
    /// </summary>
    public interface IGameManager
    {
        /// <summary>
        /// Получение списка всех игр
        /// </summary>
        /// <returns>Список моделей игр</returns>
        public Task<IEnumerable<GameResponse>> GetAllGames();

        /// <summary>
        /// Получить данные игры
        /// </summary>
        /// <param name="id">Идентификатор игры</param>
        /// <returns>Модель с данными игры</returns>
        public Task<GameResponse> GetGame(Guid id);

        /// <summary>
        /// Добавление игры
        /// </summary>
        /// <param name="game">GameRequest</param>
        /// <returns>строка с Id новой игры</returns>
        public Task<string> CreateGame(GameAddRequest game);

        /// <summary>
        /// Удаление игры
        /// </summary>
        /// <param name="id">Идентификатор игры</param>
        /// <returns>строка с Id удаленной игры</returns>
        public Task<string> DeleteGame(Guid id);

        /// <summary>
        /// Редактирование игры
        /// </summary>
        /// <param name="game">GameRequest</param>
        /// <returns>строка с Id отредактированной игры</returns>
        public Task<string> EditGame(GameUpdateRequest game);

        /// <summary>
        /// Получение игр определенного жанра
        /// </summary>
        /// <param name="genre">SearchByGenreRequest</param>
        /// <returns>Список игр</returns>
        public IEnumerable<GameResponse> GetGamesByGenres(SearchByGenreRequest genre);
    }
}
