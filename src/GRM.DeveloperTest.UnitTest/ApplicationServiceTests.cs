using GRM.DeveloperTest.Core;
using GRM.DeveloperTest.Core.Configuration;
using Xunit;

namespace GRM.DeveloperTest.UnitTest
{
    public class ApplicationServiceTests
    {
        private readonly ProjectConfiguration configuration = new ProjectConfiguration();
        public ApplicationServiceTests()
        {
            configuration.MusicDataPath = "data\\DataSource\\Music.txt";
            configuration.PartnersDataPath = "data\\DataSource\\Partners.txt";
        }

        [Fact]
        public void SearcData_data_returned()
        {
            var service = new ApplicationService(configuration);
            var data = service.SearchData("YouTube 1st April 2012");
            Assert.True(data.Count == 2);
        }
    }
}