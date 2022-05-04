using FluentValidation;
using WebApiApricode.Data.Contracts.Models.DTO;
using WebApiApricode.Data.Contracts.Models.Entities;

namespace WebApiApricode.Infrastructure.Validators
{
    internal class SearchByGenreRequestValidator : AbstractValidator<SearchByGenreRequest>
    {
        public SearchByGenreRequestValidator()
        {
            RuleFor(x => x.Genres)
                .NotEmpty()
                .Must(x => x.All(g => Enum.IsDefined(typeof(GenreEnum), g)))
                .WithMessage(ValidationMessages.InvalidValue);
        }
    }
}
