﻿namespace Application.MostWinsDuringTheDay.Commands.UpdateWin
{
    public  class UpdateMostWinDuringTheDayValidator : AbstractValidator<UpdateMostWinDuringTheDayCommand>
    {
        public UpdateMostWinDuringTheDayValidator()
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
                if (SwitchingStrenght.SwitchStrenghtFromNameToGuid(strenghtName) == Guid.Empty)
                {
                    context.AddFailure($"{nameof(UpdateMostWinDuringTheDayCommand.StrenghtName)}, {HelperValidator.NotExistInApplication}");
                }
            });
        }
    }
}
