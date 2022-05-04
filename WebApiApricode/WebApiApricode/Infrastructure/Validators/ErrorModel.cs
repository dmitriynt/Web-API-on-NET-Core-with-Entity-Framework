namespace GamesReviewsAPI.Infrastructure.Validation
{
    internal class ErrorModel
    {
        public Dictionary<string, string> Errors { get; set; }
        public string Message { get; set; }
    }
}