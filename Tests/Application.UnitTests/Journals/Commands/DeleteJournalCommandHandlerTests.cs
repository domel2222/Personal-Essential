using Application.Journals.Command.DeleteJournal;
using Domain.Entities;
using Domain.Shared;
using MediatR;

namespace Application.UnitTests.Journals.Commands
{
    public class DeleteJournalCommandHandlerTests : BaseJournalCommandHandlerTests
    {
        private readonly DeleteJournalCommandHandler _handler;

        public DeleteJournalCommandHandlerTests()
        {
            _handler = new DeleteJournalCommandHandler(_mockUnitOfWork.Object,
                                                  _mockJournalRepository.Object);
        }

        [Fact]
        public async void Handle_ForGivenValidId_DeleteJournal_SaveChangesInvokeOnceTime()
        {
            //arrange
            var allJournalsBeforeCount = (await _mockJournalRepository.Object.GetAllJournalsByUserId(_userId, CancellationToken.None)).Count();
            var deleteCommand = new DeleteJournalCommand(_journalId);

            //act
            var result = await _handler.Handle(deleteCommand, CancellationToken.None);

            var allJournaForUser = await _mockJournalRepository.Object.GetAllJournalsByUserId(_userId, cancellationToken: CancellationToken.None);

            //assert
            result.Should().BeOfType<Unit>();
            allJournaForUser.Should().HaveCount(allJournalsBeforeCount - 1);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(CancellationToken.None), Times.Once);

        }

        [Fact]
        public async void Handle_ForGivenNonExistingId_SaveChangesNeverInvoke()
        {
            var nonExistingId = new Guid("3c5981df-5e57-4d96-a981-e0231e32069c");
            //arrange
            var allJournalsBeforeCount = (await _mockJournalRepository.Object.GetAllJournalsByUserId(_userId, CancellationToken.None)).Count();
            var deleteCommand = new DeleteJournalCommand(nonExistingId);

            //act
            var result = await _handler.Handle(deleteCommand, CancellationToken.None);

            var allJournaForUser = await _mockJournalRepository.Object.GetAllJournalsByUserId(_userId, cancellationToken: CancellationToken.None);

            //assert
            result.Should().BeOfType<Unit>();
            allJournaForUser.Should().HaveCount(allJournalsBeforeCount);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(CancellationToken.None), Times.Never);
        }
    }
}
