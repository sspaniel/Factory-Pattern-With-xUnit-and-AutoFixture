using System.Collections.Generic;
using System.Threading.Tasks;
using xUnitAutoFixture.Abstractions;
using xUnitAutoFixture.Models;

namespace xUnitAutoFixture.UnitTests.Helpers
{
    public class WorkingTestLogger : ILogger
    {

        protected ICollection<Log> _logs = new LinkedList<Log>();

        public async Task AddLog(Log log)
        {
            _logs.Add(log);
        }

        public async Task<IEnumerable<Log>> GetLogs()
        {
            return _logs;
        }
    }
}