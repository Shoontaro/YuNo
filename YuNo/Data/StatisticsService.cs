using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuNo.Models;

namespace YuNo
{
    public class StatisticsService
    {
        private readonly DiaryRepository _repository;

        public StatisticsService(
            DiaryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Stat> GetStatAsync() {
            return new Stat
            {

                TotalNoCount = await _repository.GetTotalCountAsync()

            };
        }
    }
}
