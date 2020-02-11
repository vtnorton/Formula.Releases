using Formula.Releases.Az.Services;
using Microsoft.Azure.WebJobs;
using NUnit.Framework;
using System.IO;
using FluentAssertions;

namespace Formula.Releases.Az.Unit.Test.Services
{
    public class FileServiceTest
    {
        private ExecutionContext _context;
        private FileServices _fileServices;

        [SetUp]
        public void Setup()
        {
            string testPath = Directory.GetCurrentDirectory();
            _fileServices = new FileServices();

            _context = new ExecutionContext
            {
                FunctionAppDirectory = testPath
            };
        }

        [Test]
        public void ShouldGetListOfFilesPaths()
        {
            var list = _fileServices.GetFileList(_context);

            list.Should().HaveCount(2);
            list[0].Should().Contain("v1.0.0");
            list[1].Should().Contain("v2.0.0");
        }

        [Test]
        public void ShouldReturnNameOfTheReleaseFromPath()
        {
            var releaseName = "v1.5.9";
            var path = @$"C:\Unit\Tests\Data\{releaseName}.md";

            var result = _fileServices.GetReleaseName(path);

            result.Should().Be(releaseName);
        }
    }
}