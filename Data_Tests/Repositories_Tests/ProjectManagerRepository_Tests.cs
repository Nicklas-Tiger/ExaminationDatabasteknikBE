using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Datatests.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Datatests.Tests.Repositories_Tests;

public class ProjectManagerRepository_Tests
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
    public async Task GetProjectManagerAsync_ShouldReturnAllPMs()
    {
        // Arrange
        var context = GetDataContext();
        context.ProjectManagers.AddRange(TestData.ProjectManagerEntities);
        await context.SaveChangesAsync();

        IProjectManagerRepository repository = new ProjectManagerRepository(context);


        // Act
        var result = await repository.GetAllAsync();


        // Assert
        Assert.Equal(result.Count(), TestData.ProjectManagerEntities.Length);
    }
}
