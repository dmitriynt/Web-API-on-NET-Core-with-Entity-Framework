namespace WebApiApricode.Data.Contracts.Models.Entities
{
    /// <summary>
    /// Модель для хранения информации об игре 
    /// </summary>
    public class GameEntity
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
        /// Название разработчика
        /// </summary>
        public string Developer { get; set; }

        /// <summary>
        /// Список жанров
        /// </summary>
        public List<GenreEnum> Genres { get; set; }

        /// <summary>
        /// Конструктор модели
        /// </summary>
        public GameEntity()
        {
            Genres = new List<GenreEnum>();
        }
    }
}