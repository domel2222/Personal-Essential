using Application.Common.Utilities;
using Application.Journals.Queries.GetUserJournalsInSpecificDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Journals.Command.CreateJournal
{
    public sealed class CreateJournalCommandValidator : AbstractValidator<CreateJournalCommand>
    {
        public CreateJournalCommandValidator()
        {
            RuleFor(x => x.Title)
                                            .NotEmpty()
                                            .WithMessage($"{nameof(CreateJournalCommand.Title)} {HelperValidator.NotNullOrEmpty}")
                                            .MaximumLength(200);

            RuleFor(x => x.Diarydate)
                                            .NotEmpty()
                                            .WithMessage($"{nameof(CreateJournalCommand.Diarydate)} {HelperValidator.NotNullOrEmpty}");

            RuleFor(x => x.Diarydate).Custom((diaryDate, context) =>
            {
            if (!diaryDate.CompareDateToLocalTime())
                {
                    context.AddFailure($"{nameof(CreateJournalCommand.Title)} :", $" {HelperValidator.CorrectDate}");
                }
            });

            RuleFor(x => x.Userid)
                                             .NotEmpty()
                                             .WithMessage($"{nameof(CreateJournalCommand.Userid)} {HelperValidator.NotNullOrEmpty}");
        }

    }
}
