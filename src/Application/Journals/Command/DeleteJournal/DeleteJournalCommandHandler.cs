namespace Application.Journals.Command.DeleteJournal
{
    public sealed class DeleteJournalCommandHandler : ICommandHandler<DeleteJournalCommand, Unit>
    {
        private readonly IJournalRepository _journalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteJournalCommandHandler(IUnitOfWork unitOfWork, IJournalRepository journalRepository)
        {
            _unitOfWork = unitOfWork;
            _journalRepository = journalRepository;
        }

        public async Task<Unit> Handle(DeleteJournalCommand request, CancellationToken cancellationToken)
        {
            var journal = await _journalRepository.GetJournalByIdAsync(request.JournalId, cancellationToken);

            _journalRepository.Remove(journal);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}