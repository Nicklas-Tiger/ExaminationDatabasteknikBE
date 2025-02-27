using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Datatests.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Datatests.Tests.Repositories_Tests;

public class CustomerRepository_Tests
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
    public async Task GetCustomersAsync_ShouldReturnAllClients()
    {
        // Arrange
        var context = GetDataContext();
        context.Customers.AddRange(TestData.CustomerEntities);
        await context.SaveChangesAsync();

        ICustomerRepository repository = new CustomerRepository(context);


        // Act
        var result = await repository.GetAllAsync();


        // Assert
        Assert.Equal(result.Count(), TestData.CustomerEntities.Length);
    }


}
