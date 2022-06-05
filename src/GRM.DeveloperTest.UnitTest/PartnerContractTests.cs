using GRM.DeveloperTest.Core.Models;
using Xunit;

namespace GRM.DeveloperTest.UnitTest
{
    public class PartnerContractTests
    {
        [Fact]
        public void PartnerContract_parse_from_string()
        {
            var dataString = "ITunes|digital download";

            var model = PartnerContract.FromCsv(dataString);
            Assert.Equal("ITunes", model.Partner);
            Assert.Contains("digital download", model.Usages);
        }

    
    }
}