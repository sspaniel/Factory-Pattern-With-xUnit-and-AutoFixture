using System;
using AutoFixture.Kernel;
using xUnitAutoFixture.Abstractions;

namespace xUnitAutoFixture.UnitTests.Helpers
{
    public class LoggerFactory : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            SeededRequest seededRequest = request as SeededRequest;

            bool canHandleRequest = seededRequest != null && seededRequest.Request.Equals(typeof(ILogger));

            if (!canHandleRequest)
            {
                return new NoSpecimen();
            }

            switch (seededRequest.Seed)
            {
                case "fakeWorkingLogger":
                    return new WorkingTestLogger();
                default:
                    return new NoSpecimen();
            }
        }
    }
}