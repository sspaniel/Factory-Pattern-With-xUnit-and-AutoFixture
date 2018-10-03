using System.Collections.Generic;
using System.Threading.Tasks;
using xUnitAutoFixture.Models;

namespace xUnitAutoFixture.Abstractions
{
    public interface ILogger
    {
        Task AddLog(Log log);
        Task<IEnumerable<Log>> GetLogs();
    }
}
