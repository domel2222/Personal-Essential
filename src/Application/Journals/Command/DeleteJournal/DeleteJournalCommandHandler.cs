namespace Application.Journals.Command.DeleteJournal
{
    public sealed class DeleteJournalCommandHandler : ICommandHandler<DeleteJournalCommand, Result<Unit>>
    {
        private readonly IJournalRepository _journalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteJournalCommandHandler(IUnitOfWork unitOfWork, IJournalRepository journalRepository)
        {
            _unitOfWork = unitOfWork;
            _journalRepository = journalRepository;
        }

        public async Task<Result<Unit>> Handle(DeleteJournalCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteJournalCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return Utilities.CreateValidationErrorList<Unit>(validationResult);
            }

            var journal = await _journalRepository.GetByIdAsync(request.JournalId, cancellationToken);

            if(journal == null)
            {
                throw new JournalNotFoundException(request.JournalId);
            }

            _journalRepository.Remove(journal);
            await _unitOfWork.SaveChangesAsync(cancellationToken);


            return Result<Unit>.Succeed(Unit.Value);
        }
    }
}