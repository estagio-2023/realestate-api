using Microsoft.EntityFrameworkCore;
using RealEstateApiLibraryEF.DataAccess;

public class RealEstateContextTests
{
    public static RealEstateContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<RealEstateContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new RealEstateContext(options);
    }
}
