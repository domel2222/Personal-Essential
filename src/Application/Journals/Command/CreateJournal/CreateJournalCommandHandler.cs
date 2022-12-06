﻿using Domain.Entities;

namespace Application.Journals.Command.CreateJournal
{
    public sealed class CreateJournalCommandHandler : ICommandHandler<CreateJournalCommand, JournalResponse>
    {
        readonly private IJournalRepository _journalRepository;
        readonly private IUnitOfWork _unitOfWork;
        readonly private IMapper _mapper;

        public CreateJournalCommandHandler(IJournalRepository journalRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _journalRepository = journalRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<JournalResponse> Handle(CreateJournalCommand request, CancellationToken cancellationToken)
        {
            var journal = new Journal
            {
                Title = request.Title,
                Text = request.Text,
                DiaryDate = request.Diarydate,
                UserId = request.Userid
            };

            _journalRepository.Insert(journal);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            //return journal.Adapt<JournalResponse>();
            return _mapper.Map<JournalResponse>(journal);
        }
    }
}
