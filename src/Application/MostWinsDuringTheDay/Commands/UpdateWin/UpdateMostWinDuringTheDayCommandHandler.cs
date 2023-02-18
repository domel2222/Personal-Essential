namespace Application.MostWinsDuringTheDay.Commands.UpdateWin
{
    public sealed class UpdateMostWinDuringTheDayCommandHandler : ICommandHandler<UpdateMostWinDuringTheDayCommand, Result<Unit>>
    {
        private readonly IMostWinDuringTheDayRepository _mostWinDuringTheDayRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandValidator<UpdateMostWinDuringTheDayCommand> _validator;

        public UpdateMostWinDuringTheDayCommandHandler(
                                IUnitOfWork unitOfWork, 
                                IMostWinDuringTheDayRepository mostWinDuringTheDayRepository,
                                ICommandValidator<UpdateMostWinDuringTheDayCommand> validator
            )
        {
            _unitOfWork = unitOfWork;
            _mostWinDuringTheDayRepository = mostWinDuringTheDayRepository;
            _validator = validator;
        }

        public async Task<Result<Unit>> Handle(UpdateMostWinDuringTheDayCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid) 
            {
                return Utilities.CreateValidationErrorList<Unit>(validationResult);
            }

            var mostWin = await _mostWinDuringTheDayRepository.GetByIdAsync(request.MostWinId, cancellationToken);

            if (mostWin is null)
            {
                throw new SelfAssessmentValueNotFountException(request.MostWinId); 
            }

            mostWin.Message = request.Message;
            mostWin.StrenghtId = UtilitiesStrenght.SwitchStrenghtFromNameToGuid(request.StrenghtName);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return  Result<Unit>.Succeed(Unit.Value);
        }
    }
}
