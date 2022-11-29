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
            var assembly = typeof(Domain.AssemblyReference).Assembly;

            var otherProject = new[]
            {
                ApplicationNamespace,
                InfrastructureNamespace,
                PresentationNamespace,
                PersonalManagmentApiNamespace
            };
            // act
            var result = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProject)
                .GetResult();
            // assert
            result.IsSuccessful.Should().BeTrue();

        }

        [Fact]
        public void Handlers_Should_have_DependencyOnDomain()
        {
            // arrange
            var assembly = typeof(Application.AssemblyReference).Assembly;

            // act
            var result = Types
                                .InAssembly(assembly)
                                .That()
                                .HaveNameEndingWith("Handler")
                                .Should()
                                .HaveDependencyOn(DomainNamespace)
                                .GetResult();
            // assert
            result.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Application_Should_Not_HaveDependencyToOtherProjects()
        {
            // arrange
            var assembly = typeof(Application.AssemblyReference).Assembly;

            var otherProject = new[]
            {
                InfrastructureNamespace,
                PresentationNamespace,
                PersonalManagmentApiNamespace
            };
            // act
            var result = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProject)
                .GetResult();
            // assert
            result.IsSuccessful.Should().BeTrue();

        }


        [Fact]
        public void Infrastructure_Should_Not_HaveDependencyToOtherProjects()
        {
            // arrange
            var assembly = typeof(Infrastructure.AssemblyReference).Assembly;

            var otherProject = new[]
            {
                PresentationNamespace,
                PersonalManagmentApiNamespace
            };
            // act
            var result = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProject)
                .GetResult();
            // assert
            result.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Presentation_Should_Not_HaveDependencyToOtherProjects()
        {
            // arrange
            var assembly = typeof(Presentation.AssemblyReference).Assembly;

            var otherProject = new[]
            {
                InfrastructureNamespace,
                PersonalManagmentApiNamespace
            };
            // act
            var result = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProject)
                .GetResult();
            // assert
            result.IsSuccessful.Should().BeTrue();

        }

        [Fact]
        public void Presentation_Should_HaveDependencyToMediatR()
        {
            // arrange
            var assembly = typeof(Presentation.AssemblyReference).Assembly;

            // act
            var result = Types
                                .InAssembly(assembly)
                                .That()
                                .HaveNameEndingWith("Controller")
                                .Should()
                                .HaveDependencyOn("MediatR")
                                .GetResult();

            // assert
            result.IsSuccessful.Should().BeTrue();

        }
    }
}
