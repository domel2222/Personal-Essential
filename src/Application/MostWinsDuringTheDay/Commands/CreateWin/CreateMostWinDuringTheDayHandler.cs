namespace Application.MostWinsDuringTheDay.Command.CreateWin
{
    public sealed class CreateMostWinDuringTheDayHandler : ICommandHandler<CreateMostWinDuringTheDayCommand, MostWinDuringTheDayResponse>
    {
        private readonly IMostWinDuringTheDayRepository _mostWinDuringTheDayRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMostWinDuringTheDayHandler(IMostWinDuringTheDayRepository mostWinDuringTheDayRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mostWinDuringTheDayRepository = mostWinDuringTheDayRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MostWinDuringTheDayResponse> Handle(CreateMostWinDuringTheDayCommand request, CancellationToken cancellationToken)
        {
            var mostWin = new MostWinDuringTheDay
            {
                Message = request.Message,
                JournalId = request.JournalId,
                StrenghtId = UtilitiesStrenght.SwitchStrenghtFromNameToGuid(request.StrenghtName)
            };
            
            _mostWinDuringTheDayRepository.Insert(mostWin);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<MostWinDuringTheDayResponse>(mostWin);
        }
    }
}
