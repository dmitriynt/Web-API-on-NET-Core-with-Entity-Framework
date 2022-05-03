namespace WebApiApricode.Data.Contracts.Models.DTO
{
    /// <summary>
    /// Модель данных для обновления игры
    /// </summary>
    public class GameUpdateRequest
    {
        /// <summary>
        /// Идентификатор игры
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название игры
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Разработчик
        /// </summary>
        public string Developer { get; set; }

        /// <summary>
        /// Список жанров
        /// </summary>
        public List<string> Genres { get; set; }
    }
}