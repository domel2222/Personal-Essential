﻿namespace Application.UnitTests.Journals.Commands
{
    public class BaseJournalCommandHandlerTests
    {
        protected readonly Mock<IJournalRepository> _mockJournalRepository;
        protected readonly Mock<IUnitOfWork> _mockUnitOfWork;
        protected readonly Guid _journalId = new Guid("92ad89df-d618-4b8c-a369-b701de2afe51");
        protected readonly Guid _userId = new Guid("fa567cd5-1c9a-4313-aeb9-3f26f5c33d5f");

        public BaseJournalCommandHandlerTests()
        {
            _mockJournalRepository = RepositoryJournalMock.GetJournalRepository();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }
    }
}
