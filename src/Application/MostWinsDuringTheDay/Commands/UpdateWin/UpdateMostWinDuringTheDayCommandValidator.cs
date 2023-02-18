namespace Application.MostWinsDuringTheDay.Commands.UpdateWin
{
    public  class UpdateMostWinDuringTheDayCommandValidator : AbstractValidator<UpdateMostWinDuringTheDayCommand>, IMostWinDuringTheDayCommandValidator<UpdateMostWinDuringTheDayCommand>
    {
        public UpdateMostWinDuringTheDayCommandValidator()
        {
            RuleFor(x => x.MostWinId)
                                           .NotEmpty()
                                           .WithMessage($"{nameof(UpdateMostWinDuringTheDayCommand.MostWinId)} {HelperValidator.NotNullOrEmpty}");
            RuleFor(x => x.Message)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(UpdateMostWinDuringTheDayCommand.Message)} {HelperValidator.NotNullOrEmpty} ");

            RuleFor(x => x.StrenghtName)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(UpdateMostWinDuringTheDayCommand.StrenghtName)} {HelperValidator.NotNullOrEmpty}");
            RuleFor(x => x.StrenghtName).Custom((strenghtName, context) =>
            {
                if (UtilitiesStrenght.SwitchStrenghtFromNameToGuid(strenghtName) == Guid.Empty)
                {
                    context.AddFailure($"{nameof(UpdateMostWinDuringTheDayCommand.StrenghtName)}, {HelperValidator.NotExistInApplication}");
                }
            });
        }

        public Task<ValidationResult> ValidateAsync(UpdateMostWinDuringTheDayCommand command)
        {
            return Task.FromResult(Validate(command));
        }
    }
}
