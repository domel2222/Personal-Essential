namespace Application.SelfAssessments.Commands.DeleteSelfAssessmentValue
{
    public class DeleteSelfAssessmentValueHandler : ICommandHandler<DeleteSelfAssessmentValueCommand, Unit>
    {
        private readonly ISelfAssessmentValueRepository _selfAssessmentValueRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSelfAssessmentValueHandler(ISelfAssessmentValueRepository selfAssessmentValueRepository, IUnitOfWork unitOfWork)
        {
            _selfAssessmentValueRepository = selfAssessmentValueRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteSelfAssessmentValueCommand request, CancellationToken cancellationToken)
        {
            var assassment = await _selfAssessmentValueRepository.GetByIdAsync(request.SelfAssessmentValueId, cancellationToken);

            if (assassment != null)
            {
                _selfAssessmentValueRepository.Remove(assassment);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}