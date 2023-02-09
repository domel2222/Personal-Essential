namespace Application.Journals.Command.UpdateJournal
{
    public sealed class UpdateJournalCommandHandler : ICommandHandler<UpdateJournalCommand, Result<Unit>>
    {
        private readonly IJournalRepository _journalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateJournalCommandHandler(IJournalRepository journalRepository, IUnitOfWork unitOfWork)
        {
            _journalRepository = journalRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Unit>> Handle(UpdateJournalCommand request, CancellationToken cancellationToken)
        {
            
            var validator = new UpdateJournalCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return Utilities.CreateValidationErrorList<Unit>(validationResult);
            }
            
            var journal = await _journalRepository.GetByIdAsync(request.JournalId, cancellationToken);

            if (journal == null)
            {
                throw new JournalNotFoundException(request.JournalId);
            }

            journal.Title = request.Title;
            journal.Text = request.Text;
            journal.DiaryDate = request.DiaryDate.ToLocalTime();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Succeed(Unit.Value);
        }
    }
}