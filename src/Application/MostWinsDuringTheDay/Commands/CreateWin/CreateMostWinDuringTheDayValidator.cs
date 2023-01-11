using Application.SelfAssessments.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.MostWinsDuringTheDay.Command.CreateWin
{
    public  class CreateMostWinDuringTheDayValidator : AbstractValidator<CreateMostWinDuringTheDayCommand>
    {
        public CreateMostWinDuringTheDayValidator()
        {
            RuleFor(x => x.JournalId)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(CreateMostWinDuringTheDayCommand.JournalId)} {HelperValidator.NotNullOrEmpty}");
            RuleFor(x => x.Message)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(CreateMostWinDuringTheDayCommand.Message)} {HelperValidator.NotNullOrEmpty} ");

            RuleFor(x => x.StrenghtName)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(CreateMostWinDuringTheDayCommand.StrenghtName)} {HelperValidator.NotNullOrEmpty}");
            RuleFor(x => x.StrenghtName).Custom((strenghtName, context) =>
            {
                if (SwitchingStrenght.SwitchStrenghtFromNameToGuid(strenghtName) == Guid.Empty)
                {
                    context.AddFailure($"{nameof(CreateMostWinDuringTheDayCommand.StrenghtName)}, {HelperValidator.NotExistInApplication}");
                }
            });    
        }        
    }
}
