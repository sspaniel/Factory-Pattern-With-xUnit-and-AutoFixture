using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using xUnitAutoFixture.Abstractions;
using xUnitAutoFixture.Models;
using xUnitAutoFixture.UnitTests.Helpers;

namespace xUnitAutoFixture.UnitTests
{
    public class UserManagerTests
    {
        [Theory, GenerateDefaultTestData]
        public async Task AddUser_RepositoryThrowsException_IsLogged(
            User testUser,
            IUserRepository exceptionThrowingRepository,
            ILogger fakeWorkingLogger)
        {
            // Arrange
            UserManager sut = new UserManager(exceptionThrowingRepository, fakeWorkingLogger);

            // Act
            await sut.AddUser(testUser);
            IEnumerable<Log> shouldNotBeEmpty = await fakeWorkingLogger.GetLogs();

            // Assert
            Assert.NotEmpty(shouldNotBeEmpty);
        }

        [Theory, GenerateDefaultTestData]
        public async Task AddUser_GivenValidUser_ExecutesWithoutException(
            User validUser, 
            IUserRepository fakeUserRepository,
            ILogger fakeLogger)
        {
            // Arrange
            UserManager sut = new UserManager(fakeUserRepository, fakeLogger);

            // Act
            Exception shouldBeNull = await Record.ExceptionAsync(() => sut.AddUser(validUser));

            // Assert
            Assert.Null(shouldBeNull);
        }

        [Fact]
        public void CanRunXUnitTests()
        {
            Assert.True(true);
        }
    }
}
