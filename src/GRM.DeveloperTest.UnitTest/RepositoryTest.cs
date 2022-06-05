using System;
using System.Collections.Generic;
using GRM.DeveloperTest.Core.DataSource;
using GRM.DeveloperTest.Core.Models;
using Xunit;

namespace GRM.DeveloperTest.UnitTest
{
    public class RepositoryTest
    {
        private readonly MusicDataSource dataSource;

        public RepositoryTest()
        {
            dataSource = new MusicDataSource();
            dataSource.PartnerContracts.Add(new PartnerContract
                { Partner = "test1", Usages = new HashSet<string> { "1", "2" } });
            dataSource.PartnerContracts.Add(new PartnerContract
                { Partner = "test2", Usages = new HashSet<string> { "2" } });
            dataSource.PartnerContracts.Add(new PartnerContract
                { Partner = "test3", Usages = new HashSet<string> { "1" } });
            dataSource.PartnerContracts.Add(new PartnerContract
                { Partner = "test4", Usages = new HashSet<string> { "3" } });
            dataSource.PartnerContracts.Add(new PartnerContract
                { Partner = "test5", Usages = new HashSet<string> { "4" } });
        }

        [Fact]
        public void SearchMusic_read_usages_comparison()
        {
            dataSource.MusicContracts.AddRange(new[]
            {
                new MusicContract
                    { Title = "1", StartDate = new DateTime(2001, 1, 1), Usages = new HashSet<string> { "1", "2" } },
                new MusicContract
                    { Title = "2", StartDate = new DateTime(2001, 1, 1), Usages = new HashSet<string> { "1" } },
                new MusicContract
                    { Title = "1", StartDate = new DateTime(2001, 1, 1), Usages = new HashSet<string> { "2" } },
                new MusicContract
                    { Title = "1", StartDate = new DateTime(2001, 1, 1), Usages = new HashSet<string> { "3" } }
            });

            var repo = new MusicRepository(dataSource);

            var actual = repo.SearchMusic("test1", new DateTime(2001, 1, 2));
            Assert.Equal(3, actual.Count);

            actual = repo.SearchMusic("test2", new DateTime(2001, 1, 2));
            Assert.Equal(2, actual.Count);

            actual = repo.SearchMusic("test3", new DateTime(2001, 1, 2));
            Assert.Equal(2, actual.Count);

            actual = repo.SearchMusic("test4", new DateTime(2001, 1, 2));
            Assert.Equal(1, actual.Count);

            actual = repo.SearchMusic("test5", new DateTime(2001, 1, 2));
            Assert.Equal(0, actual.Count);

            actual = repo.SearchMusic("testNotFound", new DateTime(2001, 1, 2));
            Assert.Equal(0, actual.Count);
        }

        [Fact]
        public void SearchMusic_read_start_date_comparison()
        {
            dataSource.MusicContracts.AddRange(new[]
            {
                new MusicContract
                    { Title = "1", StartDate = new DateTime(2001, 1, 2), Usages = new HashSet<string> { "1", "2" } },
                new MusicContract
                    { Title = "2", StartDate = new DateTime(2001, 1, 4), Usages = new HashSet<string> { "1" } },
                new MusicContract
                    { Title = "1", StartDate = new DateTime(2001, 1, 6), Usages = new HashSet<string> { "2" } }
            });

            var repo = new MusicRepository(dataSource);

            var actual = repo.SearchMusic("test1", new DateTime(2001, 1, 10));
            Assert.Equal(3, actual.Count);

            actual = repo.SearchMusic("test1", new DateTime(2001, 1, 5));
            Assert.Equal(2, actual.Count);

            actual = repo.SearchMusic("test1", new DateTime(2001, 1, 1));
            Assert.Equal(0, actual.Count);
        }

        [Fact]
        public void SearchMusic_read_end_date_comparison()
        {
            dataSource.MusicContracts.AddRange(new[]
            {
                new MusicContract
                {
                    Title = "1", StartDate = new DateTime(2001, 1, 1), EndDate = new DateTime(2001, 1, 10),
                    Usages = new HashSet<string> { "1", "2" }
                },
                new MusicContract
                {
                    Title = "2", StartDate = new DateTime(2001, 1, 1), EndDate = new DateTime(2001, 1, 8),
                    Usages = new HashSet<string> { "1" }
                },
                new MusicContract
                {
                    Title = "1", StartDate = new DateTime(2001, 1, 1), EndDate = null,
                    Usages = new HashSet<string> { "2" }
                }
            });

            var repo = new MusicRepository(dataSource);

            var actual = repo.SearchMusic("test1", new DateTime(2001, 1, 5));
            Assert.Equal(3, actual.Count);

            actual = repo.SearchMusic("test1", new DateTime(2001, 1, 9));
            Assert.Equal(2, actual.Count);

            actual = repo.SearchMusic("test1", new DateTime(2001, 1, 11));
            Assert.Equal(1, actual.Count);
        }
    }
}