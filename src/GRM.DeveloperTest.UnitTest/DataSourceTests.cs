using GRM.DeveloperTest.Core.DataSource;
using Xunit;

namespace GRM.DeveloperTest.UnitTest
{
    public class DataSourceTests
    {
        [Fact]
        public void InitiateDataSource_data_populated()
        {
            var dataSource = new MusicDataSource("data\\DataSource\\Music.txt", "data\\DataSource\\Partners.txt");

            Assert.True(dataSource.MusicContracts.Count == 7);
            Assert.True(dataSource.PartnerContracts.Count == 2);
        }
    }
}