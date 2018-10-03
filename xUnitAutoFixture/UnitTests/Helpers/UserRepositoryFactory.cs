using AutoFixture.Kernel;
using Moq;
using System;
using xUnitAutoFixture.Abstractions;
using xUnitAutoFixture.Models;

namespace xUnitAutoFixture.UnitTests.Helpers
{
    public class UserRepositoryFactory : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            SeededRequest seededRequest = request as SeededRequest;

            bool canHandleRequest = seededRequest != null && seededRequest.Request.Equals(typeof(IUserRepository));

            if (!canHandleRequest)
            {
                return new NoSpecimen();
            }

            switch (seededRequest.Seed)
            {
                case "exceptionThrowingRepository":
                    return CreateExceptionThrowingRepository();
                default:
                    return new NoSpecimen();
            }
        }

        private object CreateExceptionThrowingRepository()
        {
            var repo = new Mock<IUserRepository>();

            repo.Setup(x => x.AddUser(It.IsAny<User>()))
                .Throws(new Exception("AddUser() threw exception"));

            return repo.Object;
        }
    }
}