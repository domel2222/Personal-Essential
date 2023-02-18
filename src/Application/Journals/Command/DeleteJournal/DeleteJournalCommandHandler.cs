namespace Application.Journals.Command.DeleteJournal
{
    public sealed class DeleteJournalCommandHandler : ICommandHandler<DeleteJournalCommand, Result<Unit>>
    {
        private readonly IJournalRepository _journalRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandValidator<DeleteJournalCommand> _validator;

        public DeleteJournalCommandHandler(IUnitOfWork unitOfWork, IJournalRepository journalRepository, ICommandValidator<DeleteJournalCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _journalRepository = journalRepository;
            _validator = validator;
        }

        public async Task<Result<Unit>> Handle(DeleteJournalCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return Utilities.CreateValidationErrorList<Unit>(validationResult);
            }

            var journal = await _journalRepository.GetByIdAsync(request.JournalId, cancellationToken);

            if (journal is null)
            {
                throw new JournalNotFoundException(request.JournalId);
            }
            else if (journal is not null)
            {
                _journalRepository.Remove(journal);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return Result<Unit>.Succeed(Unit.Value);
        }
    }
}