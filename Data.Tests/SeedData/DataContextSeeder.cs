using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.SeedData;
public static class DataContextSeeder
{
    public static DataContext GetDataContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
        .UseInMemoryDatabase(Guid.NewGuid().ToString())
         .Options;

        var context = new DataContext(options);
        context.Database.EnsureCreated();
        return context;
    }

    public static async Task SeedAsync(DataContext context)
    {
        context.Customer.AddRange(CustomerTestData);


        await context.SaveChangesAsync();
    }
}

