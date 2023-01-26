namespace Application.Journals.Queries.GetJournalList
{
    public sealed class GetJournalListQueryHandler : IQueryHandler<GetJournalsListQuery, List<JournalResponse>>
    {
        private readonly IJournalRepository _journalRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetJournalListQueryHandler(IJournalRepository journalRepository, ICurrentUserService currentUserService, IMapper mapper)
        {
            _journalRepository = journalRepository;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<List<JournalResponse>> Handle(GetJournalsListQuery request, CancellationToken cancellationToken)
        {
            var journals = await _journalRepository.GetAllJournalsByUserId(_currentUserService.guidUser, cancellationToken);

            return _mapper.Map<List<JournalResponse>(journals);
        }
    }
}