namespace WebApiApricode.Data.Contracts.Models.DTO
{
    /// <summary>
    /// Модель данных для добавления игры
    /// </summary>
    public class GameAddRequest
    {
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