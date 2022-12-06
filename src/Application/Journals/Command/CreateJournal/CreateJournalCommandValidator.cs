using Application.Common.Utilities;
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
                                            .WithMessage("Title field should not be null or empty")
                                            .MaximumLength(200);

            RuleFor(x => x.Diarydate)
                                            .NotEmpty()
                                            .WithMessage("Diary Date should not be null or empty");

            RuleFor(x => x.Diarydate).Custom((diaryDate, context) =>
            {
            if (diaryDate.CompareDateToLocalTime())
                {
                    context.AddFailure("Diary Date :", "Please insert appropriate date. Date should not be greater than actual");
                }
            });

            RuleFor(x => x.Userid)
                                             .NotEmpty()
                                             .WithMessage("User Id should not be null or empty");
        }

    }
}
