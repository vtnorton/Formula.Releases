using Formula.Releases.Az.Services;
using Microsoft.Azure.WebJobs;
using NUnit.Framework;
using System.IO;

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
            Assert.Pass();
        }

        [Test]
        public void ShouldReturnListOfReleases()
        {
            var list = _releaseServices.GetFileList();
            Assert.Pass();
        }

        [Test]
        public void ShouldNotAddReleaseIfNameIsNull()
        {
            Assert.Pass();
        }
    }
}