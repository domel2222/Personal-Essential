using Application.Journals.Command.DeleteJournal;
using Domain.Entities;
using Domain.Shared;
using MediatR;

namespace Application.UnitTests.Journals.Commands
{
    public class DeleteJournalCommandHandlerTests
    {
        private readonly Mock<IJournalRepository> _mockJournalRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly DeleteJournalCommandHandler _handler;
        private readonly Guid _journarId = new Guid("92ad89df-d618-4b8c-a369-b701de2afe51");
        private readonly Guid _userId = new Guid("fa567cd5-1c9a-4313-aeb9-3f26f5c33d5f");
        public DeleteJournalCommandHandlerTests()
        {
            _mockJournalRepository = RepositoryJournalMock.GetJournalRepository();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new DeleteJournalCommandHandler(_mockUnitOfWork.Object,
                                                  _mockJournalRepository.Object);
        }

        [Fact]
        public async void Handle_ForGivenValidId_DeleteJournal_SSaveChangesInvokeOnceTime()
        {
            //arrange
            var allJournalsBeforeCount = (await _mockJournalRepository.Object.GetAllJournalsByUserId(_userId, CancellationToken.None)).Count();
            var deleteCommand = new DeleteJournalCommand(_journarId);

            //act
            var result = await _handler.Handle(deleteCommand, CancellationToken.None);

            var allJournaForUser = await _mockJournalRepository.Object.GetAllJournalsByUserId(_userId, cancellationToken: CancellationToken.None);

            //assert
            result.Should().BeOfType<Unit>();
            allJournaForUser.Should().HaveCount(allJournalsBeforeCount - 1);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(CancellationToken.None), Times.Once);

        }
    }
}
