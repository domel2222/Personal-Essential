using Application.SelfAssessments.Commands.DeleteSelfAssessmentValue;

namespace Application.MostWinsDuringTheDay.Commands.DeleteWin
{
    public class DeleteMostWinDuringTheDayValidator : AbstractValidator<DeleteMostWinDuringTheDayCommand>
    {
        public DeleteMostWinDuringTheDayValidator()
        {
            RuleFor(x => x.MostWinId)
                                                        .NotEmpty()
                                                        .WithMessage($"{nameof(DeleteMostWinDuringTheDayCommand.MostWinId)} {HelperValidator.NotNullOrEmpty}");
        }
    }
}
