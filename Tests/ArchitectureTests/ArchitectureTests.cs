
namespace ArchitectureTests
{
    public class ArchitectureTests
    {
        private const string DomainNamespace = "Domain";
        private const string ApplicationNamespace = "Application";
        private const string InfrastructureNamespace = "Infrastructure";
        private const string PresentationNamespace = "Presentation";
        private const string PersonalManagmentApiNamespace = "PersonalManagment.Api";

        [Fact]
        public void Domain_Should_Not_HaveDependencyToOtherProjects()
        {
            // arrange
            var assemply = typeof(Domain.AssemblyReference).Assembly;

            var otherProject = new[]
            {
                DomainNamespace,
                ApplicationNamespace,
                InfrastructureNamespace,
                PresentationNamespace,
                PersonalManagmentApiNamespace
            };
            // act
            var result = Types
                .InAssembly(assemply)
                .ShouldNot()
                .HaveDependencyOnAll(otherProject)
                .GetResult();
            // assert
            result.IsSuccessful.Should().BeTrue();

        }
    }
}
