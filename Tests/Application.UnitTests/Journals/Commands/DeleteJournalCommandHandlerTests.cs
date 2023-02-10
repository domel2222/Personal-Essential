using Domain.Exceptions;

namespace Application.UnitTests.Journals.Commands
{
    public class DeleteJournalCommandHandlerTests : BaseJournalCommandHandlerTests
    {
        private readonly DeleteJournalCommandHandler _handler;
        private readonly IJournalCommandValidator<DeleteJournalCommand> _validator;
        public DeleteJournalCommandHandlerTests()
        {
            _validator = new DeleteJournalCommandValidator();
            _handler = new DeleteJournalCommandHandler(_mockUnitOfWork.Object,
                                                  _mockJournalRepository.Object,
                                                        _validator);
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
            result.Should().BeOfType<Result<Unit>>();
            allJournaForUser.Should().HaveCount(allJournalsBeforeCount - 1);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(CancellationToken.None), Times.Once);

        }

        [Fact]
        public async void Handle_ProvideWithInvalidCommand_NotDeletedJournal()
        {
            //arrange
            var emptyGuidId = Guid.Empty;
            var deleteCommand = new DeleteJournalCommand(emptyGuidId);
            var allJournalsBeforeCount = (await _mockJournalRepository.Object.GetAllJournalsByUserId(_userId, CancellationToken.None)).Count();

            //act
            var result = await _handler.Handle(deleteCommand, CancellationToken.None);
            var allJournalForUser = await _mockJournalRepository.Object.GetAllJournalsByUserId(_userId);

            //assert
            allJournalForUser.Should().HaveCount(allJournalsBeforeCount);
        }

        [Fact]
        public async void Handle_ProvideNotExistId_ThrowExeptionAndSaveChangesNeverInvoke()
        {
            //arrange
            var deleteCommand = new DeleteJournalCommand(_nonExistingId);

            //act
            Func<Task>act = () => _handler.Handle(deleteCommand, CancellationToken.None);

            //assert
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(CancellationToken.None), Times.Never);
            await act.Should().ThrowAsync<JournalNotFoundException>();

        }
    }
}
