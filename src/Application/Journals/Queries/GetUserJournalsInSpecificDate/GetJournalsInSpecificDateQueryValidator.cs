namespace Application.Journals.Queries.GetUserJournalsInSpecificDate
{
    public sealed class GetJournalsInSpecificDateQueryValidator : AbstractValidator<GetJournalsInSpecificDateQuery>
    {
        public GetJournalsInSpecificDateQueryValidator()
        {
            RuleFor(x => x.UserId)
                                            .NotEmpty()
                                            .WithMessage($"{nameof(GetJournalsInSpecificDateQuery.UserId)} {HelperValidator.CorrectDate}");

            RuleFor(x => x.DiaryDate)
                                             .NotEmpty()
                                             .WithMessage($"{nameof(GetJournalsInSpecificDateQuery.DiaryDate)} {HelperValidator.NotNullOrEmpty}");


        }
    }
}