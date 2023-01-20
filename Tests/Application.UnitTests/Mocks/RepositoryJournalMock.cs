namespace Application.UnitTests.Mocks
{
    public static class RepositoryJournalMock
    {
        
        public static Mock<IJournalRepository> GetJournalRepository() 
        {
            var journals = GetJournals();

            
            var mockJournalRepository = new Mock<IJournalRepository>();

            mockJournalRepository.Setup(repo => 
            repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(
                (Guid Id, CancellationToken cancellationToken) =>
                {
                    var journal = journals.FirstOrDefault(j => j.Id == Id);
                    return journal;
                });

            mockJournalRepository.Setup(repo => repo.Insert(It.IsAny<Journal>())).Callback<Journal>((journal) => journals.Add(journal));

            mockJournalRepository.Setup(repo => repo.Remove(It.IsAny<Journal>())).Callback<Journal>((journal) => journals.Remove(journal));

            return mockJournalRepository;
        }

        private static List<Journal> GetJournals()
        {
            var journalFirst = new Journal()
            {
                Id = new Guid("92ad89df-d618-4b8c-a369-b701de2afe51"),
                Title = "Pebrook",
                Text = "Mattke",
                DiaryDate = new DateTime(2022, 10, 11),
                UserId = new Guid("66258ef3-e856-4390-95c5-bfc429d460bc")
            };
            var journalSecond = new Journal()
            {
                Id = new Guid("6d8e3a26-e960-4a59-a2e3-9111225e83ef"),
                Title = "Wendie",
                Text = "Hatfull",
                DiaryDate = new DateTime(2023, 01, 11),
                UserId = new Guid("66258ef3-e856-4390-95c5-bfc429d460bc")
            };
            var journalThird = new Journal()
            {
                Id = new Guid("1f045e6a-77d6-472d-b2e0-abf5d7d41dd2"),
                Title = "Dalila",
                Text = "Izkovicz",
                DiaryDate = new DateTime(2022, 12, 19),
                UserId = new Guid("fa567cd5-1c9a-4313-aeb9-3f26f5c33d5f")
            };
            var journalFour = new Journal()
            {
                Id = new Guid("3616bdf3-333b-41fb-8cab-429f2026a026"),
                Title = "Dalila",
                Text = "Izkovicz",
                DiaryDate = new DateTime(2022, 12, 19),
                UserId = new Guid("fa567cd5-1c9a-4313-aeb9-3f26f5c33d5f")
            };

            var journalList = new List<Journal>();
            journalList.Add(journalFirst);
            journalList.Add(journalSecond);
            journalList.Add(journalThird);
            journalList.Add(journalFour);

            return journalList;
        }
    }
}

