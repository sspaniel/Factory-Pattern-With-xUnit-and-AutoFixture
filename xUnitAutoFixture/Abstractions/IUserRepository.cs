using System;
using System.Threading.Tasks;
using xUnitAutoFixture.Models;

namespace xUnitAutoFixture.Abstractions
{
    public interface IUserRepository : IDisposable
    {
        Task<User> AddUser(User user);
    }
}
