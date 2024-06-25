using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RealEstateApiLibraryEF.DataAccess;


namespace RealEstateXUnitTest
{
    public class RSFixture
    {
        public RealEstateContext DbContext;

        private IServiceProvider _serviceProvider;

        public RSFixture() {
            var serviceProvider = new Mock<IServiceProvider>();
            var options = new DbContextOptionsBuilder<RealEstateContext>()
                .UseInMemoryDatabase("test")
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            serviceProvider.Setup(x => x.GetService(typeof(RealEstateContext))).Returns(new RealEstateContext(options: options));

            var serviceScope = new Mock<IServiceScope>();
            serviceScope.Setup(x => x.ServiceProvider).Returns(serviceProvider.Object);

            var serviceScopeFactory = new Mock<IServiceScopeFactory>();
            serviceScopeFactory.Setup(x => x.CreateScope()).Returns(serviceScope.Object);

            serviceProvider.Setup(x => x.GetService(typeof(IServiceScopeFactory))).Returns(serviceScopeFactory.Object);

            _serviceProvider = serviceProvider.Object;

        }

        public void Initialize() {
            var options = new DbContextOptionsBuilder<RealEstateContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

            DbContext = new RealEstateContext(options);
        }
    }
}
