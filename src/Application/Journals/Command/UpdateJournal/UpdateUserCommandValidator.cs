namespace Application.Journals.Command.UpdateJournal
{
    public sealed class UpdateUserCommandValidator : AbstractValidator<UpdateJournalCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x =>x.Title)
                                                   .NotEmpty()
                                                   .WithMessage("Title field should not be null or empty")
                                                   .MaximumLength(200);

        }
    }
}
