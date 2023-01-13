using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MostWinsDuringTheDay.Commands.UpdateWin
{
    public sealed class UpdateMostWinDuringTheDayHandler : ICommandHandler<UpdateMostWinDuringTheDayCommand, Unit>
    {
        private readonly IMostWinDuringTheDayRepository _mostWinDuringTheDayRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMostWinDuringTheDayHandler(IUnitOfWork unitOfWork, IMostWinDuringTheDayRepository mostWinDuringTheDayRepository)
        {
            _unitOfWork = unitOfWork;
            _mostWinDuringTheDayRepository = mostWinDuringTheDayRepository;
        }

        public async Task<Unit> Handle(UpdateMostWinDuringTheDayCommand request, CancellationToken cancellationToken)
        {
            var mostWin = await _mostWinDuringTheDayRepository.GetByIdAsync(request.MostWinId, cancellationToken);

            if (mostWin == null)
            {
                throw new NotFoundException($"The object with the identifier {request.MostWinId} was not found"); 
            }

            mostWin.Message = request.Message;
            mostWin.StrenghtId = UtilitiesStrenght.SwitchStrenghtFromNameToGuid(request.StrenghtName);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
