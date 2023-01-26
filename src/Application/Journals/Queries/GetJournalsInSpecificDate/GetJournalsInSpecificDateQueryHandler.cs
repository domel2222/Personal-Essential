namespace Application.Journals.Queries.GetJournalsInSpecificDate
{
    public sealed class GetJournalsInSpecificDateQueryHandler : IQueryHandler<GetJournalsInSpecificDateQuery, List<JournalResponse>>
    {
        private readonly IJournalRepository _journalRepository;
        private readonly IMapper _mapper;

        public GetJournalsInSpecificDateQueryHandler(IJournalRepository journalRepository, IMapper mapper)
        {
            _journalRepository = journalRepository;
            _mapper = mapper;
        }

        public async Task<List<JournalResponse>> Handle(GetJournalsInSpecificDateQuery request, CancellationToken cancellationToken)
        {
            var journals = await _journalRepository.GetJournalByUserIdAndDateAsync(request.UserId, request.DiaryDate, cancellationToken);

            return _mapper.Map<List<JournalResponse>>(journals);
        }
    }
}