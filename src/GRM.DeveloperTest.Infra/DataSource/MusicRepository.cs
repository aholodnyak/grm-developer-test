using System;
using System.Collections.Generic;
using System.Linq;
using GRM.DeveloperTest.Core.Models;

namespace GRM.DeveloperTest.Core.DataSource
{
    public class MusicRepository
    {
        private readonly MusicDataSource _dataSource;

        public MusicRepository(MusicDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public List<MusicContract> SearchMusic(string partner, DateTime date)
        {
            var partnerContract = _dataSource.PartnerContracts.FirstOrDefault(x =>
                x.Partner.Equals(partner, StringComparison.InvariantCultureIgnoreCase));
            if (partnerContract == null)
                return new List<MusicContract>();

            return _dataSource.MusicContracts
                .Where(x => partnerContract.Usages.Overlaps(x.Usages))
                .Where(x => x.StartDate.Date.CompareTo(date.Date) <= 0)
                .Where(x => !x.EndDate.HasValue || x.EndDate?.Date.CompareTo(date.Date) >= 0)
                .ToList();
        }
    }
}