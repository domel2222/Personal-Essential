namespace Application.SelfAssessments.Commands.DeleteSelfAssessmentValue
{
    public class DeleteSelfAssessmentValueCommandHandler : ICommandHandler<DeleteSelfAssessmentValueCommand, Result<Unit>>
    {
        private readonly ISelfAssessmentValueRepository _selfAssessmentValueRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandValidator<DeleteSelfAssessmentValueCommand> _validator;

        public DeleteSelfAssessmentValueCommandHandler(
                        ISelfAssessmentValueRepository selfAssessmentValueRepository, 
                        IUnitOfWork unitOfWork, 
                        ICommandValidator<DeleteSelfAssessmentValueCommand> validator)
        {
            _selfAssessmentValueRepository = selfAssessmentValueRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<Unit>> Handle(DeleteSelfAssessmentValueCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if(!validationResult.IsValid)
            {
                return Utilities.CreateValidationErrorList<Unit>(validationResult);            
            }

            var assassment = await _selfAssessmentValueRepository.GetByIdAsync(request.SelfAssessmentValueId, cancellationToken);

            if (assassment is null)
            {
                throw new SelfAssessmentValueNotFountException(request.SelfAssessmentValueId);
            }

                _selfAssessmentValueRepository.Remove(assassment);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Succeed(Unit.Value);
        }
    }
}