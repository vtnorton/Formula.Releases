using Formula.Releases.Az.Services;
using Microsoft.Azure.WebJobs;
using NUnit.Framework;
using System.IO;
using FluentAssertions;

namespace Formula.Releases.Az.Unit.Test.Services
{
    public class ReleaseServicesTests
    {
        private ExecutionContext _context;
        private ReleaseServices _releaseServices;

        [SetUp]
        public void Setup()
        {
            string testPath = Directory.GetCurrentDirectory();
            FileServices fileServices = new FileServices();

            _context = new ExecutionContext
            {
                FunctionAppDirectory = testPath
            };

            _releaseServices = new ReleaseServices(fileServices);
        }

        [Test]
        public void ShouldReturnListOfReleases()
        {
            var list = _releaseServices.GetReleases(_context);
            
            list.Should().HaveCount(2);
            list[0].VersionName.Should().Be("v1.0.0");
            list[1].VersionName.Should().Be("v2.0.0");
        }
    }
}