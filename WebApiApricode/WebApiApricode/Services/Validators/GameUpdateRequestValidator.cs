using FluentValidation;
using WebApiApricode.Data.Contracts.Models.DTO;
using WebApiApricode.Data.Contracts.Models.Entities;

namespace WebApiApricode.Services.Validators
{
    internal class GameUpdateRequestValidator : AbstractValidator<GameUpdateRequest>
    {
        public GameUpdateRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage(ValidationMessages.CannotBeEmpty);
            RuleFor(x => x.Developer)
                .NotEmpty()
                .WithMessage(ValidationMessages.CannotBeEmpty);
            _ = RuleFor(x => x.Genres)
                .NotEmpty()
                .Must(x => x.All(g => Enum.IsDefined(typeof(GenreEnum), g)))
                .WithMessage(ValidationMessages.InvalidValue);
        }
    }
}
