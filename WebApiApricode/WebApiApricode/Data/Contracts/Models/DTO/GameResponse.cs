namespace WebApiApricode.Data.Contracts.Models.DTO
{
    /// <summary>
    /// Возвращаемая модель данных игры
    /// </summary>
    public class GameResponse
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