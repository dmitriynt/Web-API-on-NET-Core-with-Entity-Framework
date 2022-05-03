namespace WebApiApricode.Data.Contracts.Models.DTO
{
    /// <summary>
    /// Модель данных для поиска по жанру
    /// </summary>
    public class SearchByGenreRequest
    {
        /// <summary>
        /// Список жанров
        /// </summary>
        public List<string> Genres{ get; set; }
    }
}