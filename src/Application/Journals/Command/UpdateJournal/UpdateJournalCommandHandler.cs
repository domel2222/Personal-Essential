namespace Application.Journals.Command.UpdateJournal
{
    public sealed class UpdateJournalCommandHandler : ICommandHandler<UpdateJournalCommand, Result<Unit>>
    {
        private readonly IJournalRepository _journalRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandValidator<UpdateJournalCommand> _validator;

        public UpdateJournalCommandHandler(
                            IJournalRepository journalRepository, 
                            IUnitOfWork unitOfWork, 
                            ICommandValidator<UpdateJournalCommand> validator)
        {
            _journalRepository = journalRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<Unit>> Handle(UpdateJournalCommand request, CancellationToken cancellationToken)
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

            journal.Title = request.Title;
            journal.Text = request.Text;
            journal.DiaryDate = request.DiaryDate.ToLocalTime();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Succeed(Unit.Value);
        }
    }
}