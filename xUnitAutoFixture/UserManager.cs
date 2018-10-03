using System;
using System.Threading.Tasks;
using xUnitAutoFixture.Abstractions;
using xUnitAutoFixture.Models;

namespace xUnitAutoFixture
{
    public class UserManager
    {
        protected IUserRepository _userRepository { get; set; }
        protected ILogger _logger { get; set; }

        public UserManager(IUserRepository userRepository, ILogger logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<User> AddUser(User user)
        {
            try
            {
                user  = await _userRepository.AddUser(user);
                return user;
            }
            catch (Exception e)
            {
                Log exceptionLog = new Log(e.ToString());
                await _logger.AddLog(exceptionLog);
            }

            return null;
        }
    }
}
