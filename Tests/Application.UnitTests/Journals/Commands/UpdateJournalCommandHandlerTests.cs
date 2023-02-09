using Application.Journals.Command.UpdateJournal;

namespace Application.UnitTests.Journals.Commands
{
    public class UpdateJournalCommandHandlerTests : BaseJournalCommandHandlerTests
    {
        private readonly UpdateJournalCommandHandler _handler;

        public UpdateJournalCommandHandlerTests()
        {
            _handler = new UpdateJournalCommandHandler(_mockJournalRepository.Object,
                                                            _mockUnitOfWork.Object);
        }

        [Fact]
        public async void Handle_ForGivenValidCommand_ShouldUpdateJournal_SaveInvokeOnceTime()
        {

        }
    }
}
