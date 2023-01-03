using Application.Journals.Command.UpdateJournal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SelfAssessments.Commands.UpdateSelfAssessmentValue
{
    public class UpdateSelfAssessmentValueValidator : AbstractValidator<UpdateSelfAssessmentValueCommand>
    {
        public UpdateSelfAssessmentValueValidator()
        {
            RuleFor(x => x.SelfAssessmentValueId)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(UpdateSelfAssessmentValueCommand.SelfAssessmentValueId)} {HelperValidator.NotNullOrEmpty}");

            RuleFor(x => x.AssesmentDate).Custom((diaryDate, context) =>
            {
                if (!diaryDate.CompareDateToLocalTime())
                {
                    context.AddFailure($"{nameof(UpdateJournalCommand.Title)} :", $"{HelperValidator.CorrectDate}");
                }
            });
        }
    }
}
