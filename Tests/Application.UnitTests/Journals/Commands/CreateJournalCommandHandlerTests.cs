namespace Application.UnitTests.Journals.Commands
{
    public class CreateJournalCommandHandlerTests : BaseJournalCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly CreateJournalCommandHandler _handler;
        private readonly Guid _guidUserForCommand = new Guid("8316ad31-e815-41d6-9d00-26392977132a");

        public CreateJournalCommandHandlerTests()
        {
            _mapper = AddMapsterForUnitTests.GetMapper();
            _handler = new CreateJournalCommandHandler(_mockJournalRepository.Object,
                                                            _mockUnitOfWork.Object,
                                                               _mapper);
        }

        [Fact]
        public async void Handle_ForGivenValidCommand_ShouldCreateJournal_OnceTime()
        {
            //arrange
            var command = new CreateJournalCommand
            (
                "My Journal",
                "Today was a great day.",
                DateTime.Now,
                _guidUserForCommand
            );

            //act
            var allJournalsBeforeCount = (await _mockJournalRepository.Object.GetAllJournalsByUserId(_userId, CancellationToken.None)).Count();
            var result = await _handler.Handle(command, CancellationToken.None);
            var allJournalsForUser = await _mockJournalRepository.Object.GetAllJournalsByUserId(_userId, CancellationToken.None);

            //assert
            result.Value.UserId.Should().Be(command.Userid);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(CancellationToken.None), Times.Once);
            allJournalsForUser.Should().HaveCount(allJournalsBeforeCount + 1);

        }

        [Fact]
        public async void Handle_ForGivenInValidCommand_ShouldNotCreateJournal_InvokeSaveChangesNever()
        {
            //arrange
            var commandInvalid = new CreateJournalCommand
            (
                "Newst Journal",
                "",
                DateTime.Now.AddDays(1),
                _guidUserForCommand
            );

            //act
            var allJournalsBeforeCount = (await _mockJournalRepository.Object.GetAllJournalsByUserId(_guidUserForCommand, CancellationToken.None)).Count();
            var result = await _handler.Handle(commandInvalid, CancellationToken.None);

            //assert
            var allJournalsForUser = await _mockJournalRepository.Object.GetAllJournalsByUserId(_guidUserForCommand, CancellationToken.None);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(CancellationToken.None), Times.Never);
        }
    }
}