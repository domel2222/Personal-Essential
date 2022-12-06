namespace Application.Journals.Command.UpdateJournal
{
    public sealed class UpdateUserCommandHandler : ICommandHandler<UpdateJournalCommand, Unit>
    {
        private readonly IJournalRepository _journalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IJournalRepository journalRepository, IUnitOfWork unitOfWork)
        {
            _journalRepository = journalRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateJournalCommand request, CancellationToken cancellationToken)
        {
            var journal = await _journalRepository.GetJournalById(request.JournalId, cancellationToken);

            if (journal == null)
            {
                throw new JournalNotFoundException(request.JournalId);
            }

            journal.Title = request.Title;
            journal.Text = request.Text;
            journal.DiaryDate = request.DiaryDate;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}