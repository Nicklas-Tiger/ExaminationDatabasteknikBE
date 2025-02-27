using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Datatests.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Datatests.Tests.Repositories_Tests;

public class ServiceRepository_Tests
{
    private DataContext GetDataContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new DataContext(options);
        context.Database.EnsureCreated();
        return context;
    }
    [Fact]
    public async Task GetServiceAsync_ShouldReturnAllServices()
    {
        // Arrange
        var context = GetDataContext();
        context.Services.AddRange(TestData.ServiceEntities);
        await context.SaveChangesAsync();

        IServiceRepository repository = new ServiceRepository(context);


        // Act
        var result = await repository.GetAllAsync();


        // Assert
        Assert.Equal(result.Count(), TestData.ServiceEntities.Length);
    }
}
