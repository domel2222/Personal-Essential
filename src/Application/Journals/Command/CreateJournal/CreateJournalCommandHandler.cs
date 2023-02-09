namespace Application.Journals.Command.CreateJournal
{
    public sealed class CreateJournalCommandHandler : ICommandHandler<CreateJournalCommand, Result<JournalResponse>>
    {
        private readonly IJournalRepository _journalRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICommandValidator<CreateJournalCommand> _validator;

        public CreateJournalCommandHandler(
                        IJournalRepository journalRepository, 
                        IUnitOfWork unitOfWork, 
                        IMapper mapper, 
                        ICommandValidator<CreateJournalCommand> validator)
        {
            _journalRepository = journalRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Result<JournalResponse>> Handle(CreateJournalCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return Utilities.CreateValidationErrorList<JournalResponse>(validationResult);
            }

            var journal = new Journal
            {
                Title = request.Title,
                Text = request.Text,
                DiaryDate = request.Diarydate,
                UserId = request.Userid
            };

            _journalRepository.Insert(journal);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<JournalResponse>.Succeed(_mapper.Map<JournalResponse>(journal));
        }
    }
}