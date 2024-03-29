﻿namespace Application.Journals.Command.UpdateJournal
{
    public sealed class UpdateJournalCommandValidator : AbstractValidator<UpdateJournalCommand>
    {
        public UpdateJournalCommandValidator()
        {
            RuleFor(x => x.Title)
                                                   .NotEmpty()
                                                   .WithMessage($"{nameof(UpdateJournalCommand.Title)} {HelperValidator.NotNullOrEmpty}")
                                                   .MaximumLength(200);

            RuleFor(x => x.DiaryDate).Custom((diaryDate, context) =>
            {
                if (!diaryDate.CompareDateToLocalTime())
                {
                    context.AddFailure($"{nameof(UpdateJournalCommand.Title)} :", $"{HelperValidator.CorrectDate}");
                }
            });
        }
    }
}