using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MostWinsDuringTheDay.Commands.DeleteWin
{
    public sealed class DeleteMostWinDuringTheDayHandler : ICommandHandler<DeleteMostWinDuringTheDayCommand, Unit>
    {
        private readonly IMostWinDuringTheDayRepository _mostWinDuringTheDayRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMostWinDuringTheDayHandler(IMostWinDuringTheDayRepository mostWinDuringTheDayRepository, IUnitOfWork unitOfWork)
        {
            _mostWinDuringTheDayRepository = mostWinDuringTheDayRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteMostWinDuringTheDayCommand request, CancellationToken cancellationToken)
        {
            var mostWin = await _mostWinDuringTheDayRepository.GetByIdAsync(request.MostWinId, cancellationToken);

            if (mostWin != null) 
            {
                _mostWinDuringTheDayRepository.Remove(mostWin);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
