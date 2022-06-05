using System.Collections.Generic;
using GRM.DeveloperTest.Core.Common;
using GRM.DeveloperTest.Core.Configuration;
using GRM.DeveloperTest.Core.DataSource;
using GRM.DeveloperTest.Core.Models;

namespace GRM.DeveloperTest.Core
{
    public class ApplicationService
    {
        private readonly MusicRepository _musicRepository;

        public ApplicationService(ProjectConfiguration configuration)
        {
            var dataSource = new MusicDataSource(configuration.MusicDataPath, configuration.PartnersDataPath);
            _musicRepository = new MusicRepository(dataSource);
        }

        public List<MusicContract> SearchData(string searchString)
        {
            var parsedData = StringUtils.ParseSearchString(searchString);
            return _musicRepository.SearchMusic(parsedData.partner, parsedData.date);
        }
    }
}