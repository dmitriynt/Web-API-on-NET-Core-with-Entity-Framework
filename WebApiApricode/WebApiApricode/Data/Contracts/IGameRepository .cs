using WebApiApricode.Data.Contracts.Models.Entities;

namespace WebApiApricode.Data.Contracts
{
    /// <summary>
    /// Описание методов репозитория
    /// </summary>
    internal interface IGameRepository
    {
        /// <summary>
        /// Получение всех записей из таблицы
        /// </summary>
        public Task<IEnumerable<GameEntity>> GetAll();

        /// <summary>
        /// Получение информации об игре
        /// </summary>
        /// <param name="id">Идентификатор игры</param>
        public Task<GameEntity> GetGame(Guid id);

        /// <summary>
        /// Добавление записи в таблицу
        /// </summary>
        /// <param name="game">Данные игры</param>
        public Task<string> Add(GameEntity game);

        /// <summary>
        /// Обновление записи в таблице
        /// </summary>
        /// <param name="target">Данные, которые нужно обновить</param>
        /// <param name="source">Новые данные</param>

        public Task<string> Update(GameEntity target, GameEntity source);

        /// <summary>
        /// Удаление записи из таблицы
        /// </summary>
        /// <param name="game">Модель игры</param>
        public Task<string> Remove(GameEntity game);

        /// <summary>
        /// Получение всех игр, соответствующих указанным жанрам
        /// </summary>
        /// <param name="genre">Список жанров</param>
        public List<GameEntity> GetGamesByGenres(List<GenreEnum> genre);
    }
}