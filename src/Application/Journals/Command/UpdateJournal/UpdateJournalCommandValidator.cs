namespace Application.Journals.Command.UpdateJournal
{
    public sealed class UpdateJournalCommandValidator : AbstractValidator<UpdateJournalCommand>
    {
        public UpdateJournalCommandValidator()
        {
            RuleFor(x => x.Title)
                                                   .NotEmpty()
                                                   .WithMessage("Title field should not be null or empty")
                                                   .MaximumLength(200);

            RuleFor(x => x.DiaryDate).Custom((diaryDate, context) =>
            {
                if (!diaryDate.CompareDateToLocalTime())
                {
                    context.AddFailure("Diary Date :", "Please insert appropriate date. Date should not be greater than actual");
                }
            });
        }
    }
}