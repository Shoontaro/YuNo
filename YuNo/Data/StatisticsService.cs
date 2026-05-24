using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuNo
{
    public class StatisticsService
    {
        private readonly DiaryRepository _repository;
        private readonly SettingsService _settings;

        public StatisticsService(
            DiaryRepository repository, SettingsService settings)
        {
            _repository = repository;
            _settings = settings;
        }

        public async Task<Stat> GetStatAsync() {
            return new Stat
            {

                TotalNoCount = await _repository.GetTotalCountAsync(),
                Goal = _settings.Goal

            };
        }
    }
}
