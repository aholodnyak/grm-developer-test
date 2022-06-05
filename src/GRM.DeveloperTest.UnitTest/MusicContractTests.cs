using System;
using System.Collections.Generic;
using System.Text;
using GRM.DeveloperTest.Core.Models;
using Xunit;

namespace GRM.DeveloperTest.UnitTest
{
    public class MusicContractTests
    {
        [Fact]
        public void MusicContract_parse_from_string_all_dates()
        {
            var dataString = "Monkey Claw|Christmas Special|streaming|25th Dec 2012|31st Dec 2012";

            var model = MusicContract.FromCsv(dataString);
            Assert.Equal("Monkey Claw", model.Artist);
            Assert.Equal("Christmas Special", model.Title);
            Assert.Equal("Christmas Special", model.Title);
            Assert.Equal(new DateTime(2012,12,25), model.StartDate);
            Assert.Equal(new DateTime(2012,12, 31), model.EndDate);
        }

        [Fact]
        public void MusicContract_parse_from_string_empty_end_date()
        {
            var dataString = "Monkey Claw|Christmas Special|streaming|25th Dec 2012|";

            var model = MusicContract.FromCsv(dataString);
            Assert.Equal("Monkey Claw", model.Artist);
            Assert.Equal("Christmas Special", model.Title);
            Assert.Equal("Christmas Special", model.Title);
            Assert.Equal(new DateTime(2012, 12, 25), model.StartDate);
            Assert.Equal(null, model.EndDate);
        }


        [Fact]
        public void MusicContract_toString_all()
        {
            var model = new MusicContract
            {
                Usages = new HashSet<string> { "streaming" },
                EndDate = new DateTime(2012, 12, 31),
                StartDate = new DateTime(2012, 12, 25),
                Artist= "Monkey Claw",
                Title = "Christmas Special"
            };
            var expected = "Monkey Claw|Christmas Special|streaming|25th Dec 2012|31st Dec 2012";
            Assert.Equal(expected,model.ToString());
        }

        [Fact]
        public void MusicContract_toString_empty_end_date()
        {
            var model = new MusicContract
            {
                Usages = new HashSet<string> { "streaming" },
                EndDate = null,
                StartDate = new DateTime(2012, 12, 25),
                Artist = "Monkey Claw",
                Title = "Christmas Special"
            };
            var expected = "Monkey Claw|Christmas Special|streaming|25th Dec 2012|";
            Assert.Equal(expected, model.ToString());
        }
    }
}
