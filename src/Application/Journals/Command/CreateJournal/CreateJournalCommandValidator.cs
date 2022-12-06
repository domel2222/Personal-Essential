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

            RuleFor(x => x.Diarydate).NotEmpty().WithMessage("Diary Date should not be null or empty");

            RuleFor(x => x.Diarydate).Custom((diaryDate, context) =>
            {
                if (!CompareDate(diaryDate))
                {
                    context.AddFailure("Email :", "Please insert appropriate date. Date should not be greater than actual");
                }
            });
            //check guid 000 - 0000 - 000000
            RuleFor(x => x.Userid).NotEmpty().WithMessage("User Id should not be null or empty");
        }

        private bool CompareDate(DateTime incomingDate)
        {
            var localTime = DateTime.Now.ToLocalTime();
            var localDateOnly = new DateOnly(localTime.Year, localTime.Month, localTime.Day);
            var incomingDateOnly = new DateOnly(incomingDate.Year, incomingDate.Month, incomingDate.Day);

            return (incomingDateOnly <= localDateOnly);
        }
    }
}
