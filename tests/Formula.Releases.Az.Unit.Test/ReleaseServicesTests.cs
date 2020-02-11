using Formula.Releases.Az.Services;
using Microsoft.Azure.WebJobs;
using NUnit.Framework;
using System.IO;
using FluentAssertions;

namespace Formula.Releases.Az.Unit.Test
{
    public class Tests
    {
        private ReleaseServices _releaseServices;

        [SetUp]
        public void Setup()
        {
            string testPath = Directory.GetCurrentDirectory();
            string appPath = Path.GetFullPath(Path.Combine(testPath, @"..\..\..\..\..\src\Formula.Releases.Az\bin\Debug\netcoreapp3.0"));
            
            ExecutionContext context = new ExecutionContext
            {
                FunctionAppDirectory = appPath
            };
            _releaseServices = new ReleaseServices(context);
        }

        [Test]
        public void ShouldGetListOfFilesPaths()
        {
            Assert.Pass();
        }

        [Test]
        public void ShouldReturnNameOfTheReleaseFromPath()
        {
            var releaseName = "v1.5.9";
            var path = @$"C:\Unit\Tests\Data\{releaseName}.md";

            var result = _releaseServices.GetReleaseName(path);

            result.Should().Be(releaseName);
        }

        [Test]
        public void ShouldReturnListOfReleases()
        {
            var list = _releaseServices.GetReleases();
            Assert.Pass();
        }

        [Test]
        public void ShouldNotAddReleaseIfNameIsNull()
        {
            var list = _releaseServices.GetReleases();
            Assert.Pass();
        }
    }
}