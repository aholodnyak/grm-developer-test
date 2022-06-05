using System.Collections.Generic;
using System.Linq;
using GRM.DeveloperTest.Core.Common;
using GRM.DeveloperTest.Core.Models;

namespace GRM.DeveloperTest.Core.DataSource
{
    public class MusicDataSource
    {
        public MusicDataSource()
        {
            MusicContracts = new List<MusicContract>();
            PartnerContracts = new List<PartnerContract>();
        }

        public MusicDataSource(string musicFilePath, string partnerFilePath)
        {
            InitiateDataSource(musicFilePath, partnerFilePath);
        }

        public List<MusicContract> MusicContracts { get; private set; }
        public List<PartnerContract> PartnerContracts { get; private set; }

        private void InitiateDataSource(string musicFilePath, string partnerFilePath)
        {
            var musicRows = FileUtils.ReadFileLines(musicFilePath);
            MusicContracts = musicRows.Select(x => MusicContract.FromCsv(x)).ToList();

            var partnerRows = FileUtils.ReadFileLines(partnerFilePath);
            PartnerContracts = partnerRows.Select(x => PartnerContract.FromCsv(x)).ToList();
        }
    }
}