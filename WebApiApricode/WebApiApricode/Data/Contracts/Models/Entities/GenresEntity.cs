namespace WebApiApricode.Data.Contracts.Models.Entities
{
    /// <summary>
    /// Модель для выполнения операций с жанрами
    /// </summary>
    public class GenresEntity
    {
        /// <summary>
        /// Список жанров
        /// </summary>
        public List<GenreEnum> Genres { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public GenresEntity()
        {
            Genres = new List<GenreEnum>();
        }
    }
}
