using Application.Journals.Command.UpdateJournal;

namespace Application.UnitTests.Journals.Commands
{
    public class UpdateJournalCommandHandlerTests : BaseJournalCommandHandlerTests
    {
        private readonly UpdateJournalCommandHandler _handler;
        private readonly IJournalCommandValidator<UpdateJournalCommand> _validator;
        private readonly Guid _journalToUpdate = new Guid("92ad89df-d618-4b8c-a369-b701de2afe51");
        public UpdateJournalCommandHandlerTests()
        {
            _validator = new UpdateJournalCommandValidator();
            _handler = new UpdateJournalCommandHandler(_mockJournalRepository.Object,
                                                            _mockUnitOfWork.Object, 
                                                             _validator);
        }

        [Fact]
        public async void Handle_ForGivenValidCommand_ShouldUpdateJournal_SaveInvokeOnceTime()
        {
            //arrange
            var command = new UpdateJournalCommand
            (
                 _journalToUpdate,
                 "New Value",
                "Test has a new value",
                DateTime.Now
            );

            //act
            var result = await _handler.Handle(command, CancellationToken.None);
            var journalFromDb = await _mockJournalRepository.Object.GetByIdAsync(_journalToUpdate, CancellationToken.None);

            //assert
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(CancellationToken.None), Times.Once);
            result.Should().BeOfType<Result<Unit>>();
            journalFromDb.Title.Should().Be(command.Title);
            journalFromDb.Text.Should().Be(command.Text);
        }

        [Fact]
        public async void Handle_ForGivenINValidCommand_ShouldNotUpdatedJournal_SaveInvokeNever()
        {
            //arrange
            var command = new UpdateJournalCommand
            (
                 _journalToUpdate,
                 "New Value",
                "Test has a new value",
                DateTime.Now
            );

            //act
            var result = await _handler.Handle(command, CancellationToken.None);
            var journalFromDb = await _mockJournalRepository.Object.GetByIdAsync(_journalToUpdate, CancellationToken.None);

            //assert
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(CancellationToken.None), Times.Never);
            journalFromDb.Text.Should().NotBe(command.Text);
        }

        [Fact]
        public async void Handle_ProvideNotExistId_ThrowExeption()
        {
            var command = new UpdateJournalCommand
            (
                 _nonExistingId,
                 "",
                "Test has a new value",
                DateTime.Now
            );
        }
    }
}
