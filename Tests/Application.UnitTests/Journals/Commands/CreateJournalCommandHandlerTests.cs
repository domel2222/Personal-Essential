using System;
using Application.Contracts.Journals;
using Application.Journals.Command.CreateJournal;
using Application.UnitTests.Mocks;
using MapsterMapper;

namespace Application.UnitTests.Journals.Commands
{
    public class CreateJournalCommandHandlerTests
    {
        private readonly Mock<IJournalRepository> _mockJournalRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly IMapper _mapper;
        private readonly CreateJournalCommandHandler _handler;
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
            var guid = new Guid("8316ad31-e815-41d6-9d00-26392977132a");
            //var sampleId = Guid("");
            //arrange
            var command = new CreateJournalCommand
            (
                "My Journal",
                "Today was a great day.",
                DateTime.Now,
                guid
            );
            //var expectedJournal = new Journal
            //{
            //    Title = command.Title,
            //    Text = command.Text,
            //    DiaryDate = command.Diarydate,
            //    UserId = command.Userid
            //};


            //var journalsCount = _mockJournalRepository.Invocations.Count(x => x.Method.Name == "Insert");


            //_mockJournalRepository.Setup(repo => repo.Insert(It.IsAny<Journal>())).Callback((Journal j) =>
            //{
            //    j.Id = guid;
            //});

            //_mapper.Setup(m => m.Map<JournalResponse>(It.IsAny<Journal>())).Returns(new JournalResponse("Title","Text", DateTime.Now, new Guid()));

            ////act
            //var journalsCount = _mockJournalRepository.Invocations.Count(x => x.Method.Name == "Insert");
            //var response = await _handler.Handle(command, CancellationToken.None);

            
            //var result = await _handler.Handle(command, CancellationToken.None);

            ////assert

            //Add method get all
            //_mockJournalRepository.Verify(r => r.Insert(It.Is<Journal>(j => j.Title == expectedJournal.Title && j.UserId == expectedJournal.UserId)), Times.Once);

            //_mockUnitOfWork.Verify(u => u.SaveChangesAsync(CancellationToken.None), Times.Once);
            //await _mockJournalRepository.Object.


            //response.Should().BeOfType<JournalResponse>();

            var mockJournalRepository = RepositoryJournalMock.GetJournalRepository();
            int journalCount = mockJournalRepository.Invocations.Count(x => x.Method.Name == "Insert");
            Assert.Equal(4, journalCount);
            
        }
    }
}