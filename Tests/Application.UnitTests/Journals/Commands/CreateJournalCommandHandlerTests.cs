namespace Application.UnitTests.Journals.Commands
{
    public class CreateJournalCommandHandlerTests
    {
        private readonly Mock<IJournalRepository> _mockJournalRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly IMapper _mapper;
        private readonly CreateJournalCommandHandler _handler;

        private readonly Guid _userId = new Guid("fa567cd5-1c9a-4313-aeb9-3f26f5c33d5f");
        private readonly Guid _guidUserForCommand = new Guid("8316ad31-e815-41d6-9d00-26392977132a");
        private readonly Guid _journalId = new Guid("92ad89df-d618-4b8c-a369-b701de2afe51");

        public CreateJournalCommandHandlerTests()
        {
            _mockJournalRepository = RepositoryJournalMock.GetJournalRepository();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
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
            //var expectedJournal = new Journal
            //{
            //    Title = command.Title,
            //    Text = command.Text,
            //    DiaryDate = command.Diarydate,
            //    UserId = command.Userid
            //};

            var allJournalsBeforeCount = (await _mockJournalRepository.Object.GetAllJournalsByUserId(_userId, CancellationToken.None)).Count();

            //var journalsCount = _mockJournalRepository.Invocations.Count(x => x.Method.Name == "Insert");

            //_mockJournalRepository.Setup(repo => repo.Insert(It.IsAny<Journal>())).Callback((Journal j) =>
            //{
            //    j.Id = guid;
            //});

            //_mapper.Setup(m => m.Map<JournalResponse>(It.IsAny<Journal>())).Returns(new JournalResponse("Title","Text", DateTime.Now, new Guid()));

            ////act
            //var journalsCount = _mockJournalRepository.Invocations.Count(x => x.Method.Name == "Insert");
            //var response = await _handler.Handle(command, CancellationToken.None);

            var result = await _handler.Handle(command, CancellationToken.None);
            var allJournalsForUser = await _mockJournalRepository.Object.GetAllJournalsByUserId(_userId, CancellationToken.None);
            ////assert

            //Add method get all
            //_mockJournalRepository.Verify(r => r.Insert(It.Is<Journal>(j => j.Title == expectedJournal.Title && j.UserId == expectedJournal.UserId)), Times.Once);

            //await _mockJournalRepository.Object.

            //response.Should().BeOfType<JournalResponse>();

            //assert
            result.Value.UserId.Should().Be(command.Userid);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(CancellationToken.None), Times.Once);
            allJournalsForUser.Should().HaveCount(allJournalsBeforeCount + 1);

            //var mockJournalRepository = RepositoryJournalMock.GetJournalRepository();
            //int journalCount = mockJournalRepository.Invocations.Count(x => x.Method.Name == "Insert");
            //Assert.Equal(4, journalCount);
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