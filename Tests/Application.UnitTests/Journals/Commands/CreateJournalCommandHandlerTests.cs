using Application.Contracts.Journals;
using Application.Journals.Command.CreateJournal;
using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;
using System.Reflection.Metadata;

namespace Application.UnitTests.Journals.Commands
{
    public class CreateJournalCommandHandlerTests
    {
        private readonly Mock<IJournalRepository> _mockJournalRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CreateJournalCommandHandler _handler;
        public CreateJournalCommandHandlerTests()
        {
            _mockJournalRepository = new Mock<IJournalRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _handler = new CreateJournalCommandHandler(_mockJournalRepository.Object,
                                                            _mockUnitOfWork.Object,
                                                               _mockMapper.Object);
        }
        [Fact]
        public async void Handle_ForGivenValidCommand_ShouldCreateJournal_OnceTime()
        {
            var guid = new Guid("8316ad31-e815-41d6-9d00-26392977132a");
            //arrange
            var command = new CreateJournalCommand
            (
                "My Journal",
                "Today was a great day.",
                DateTime.Now,
                guid
            );
            var expectedJournal = new Journal
            {
                Title = command.Title,
                Text = command.Text,
                DiaryDate = command.Diarydate,
                UserId = command.Userid
            };

            _mockJournalRepository.Setup(repo => repo.Insert(It.IsAny<Journal>())).Callback((Journal j) =>
            {
                j.Id = guid;
            });

            _mockMapper.Setup(m => m.Map<JournalResponse>(It.IsAny<Journal>())).Returns(new JournalResponse("Title","Text", DateTime.Now, new Guid()));

            //act
            var result = await _handler.Handle(command, CancellationToken.None);

            //assert
            _mockJournalRepository.Verify(r => r.Insert(It.Is<Journal>(j => j.Title == expectedJournal.Title && j.UserId == expectedJournal.UserId)), Times.Once);

            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(CancellationToken.None), Times.Once);

            result.Should().BeOfType<JournalResponse>();
        }
    }
}