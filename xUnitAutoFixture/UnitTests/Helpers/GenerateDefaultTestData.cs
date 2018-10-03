using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace xUnitAutoFixture.UnitTests.Helpers
{
    public class GenerateDefaultTestData : AutoDataAttribute
    {
        public GenerateDefaultTestData() : base(GetDefaultFixture)
        {
        }

        public static IFixture GetDefaultFixture()
        {
            var userRepositoryFactory = new UserRepositoryFactory();
            var loggerFactory = new LoggerFactory();
            var autoMoqCustomization = new AutoMoqCustomization();

            IFixture fixture = new Fixture();
            fixture.Customizations.Add(userRepositoryFactory);
            fixture.Customizations.Add(loggerFactory);
            fixture.Customize(autoMoqCustomization);

            return fixture;
        }
    }
}
