using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Datatests.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Datatests.Tests.Repositories_Tests;

public class ProjectRepository_Tests
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
    public async Task AddAsync_ShouldCreateProjectAndReturnProject()
    {
        // Arrange
        var context = GetDataContext();
        context.Customers.AddRange(TestData.CustomerEntities);
        context.ProjectManagers.AddRange(TestData.ProjectManagerEntities);
        context.Statuses.AddRange(TestData.StatusEntities);
        context.Services.AddRange(TestData.ServiceEntities);

        await context.SaveChangesAsync();
        IProjectRepository repository = new ProjectRepository(context);

        var projectEntity = TestData.ProjectEntities[0];

        // Act
        var result = await repository.AddAsync(projectEntity);


        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task GetAsync_ShouldReturnCorrectProject()
    {
        // Arrange
        var context = GetDataContext();
        context.Customers.AddRange(TestData.CustomerEntities);
        context.ProjectManagers.AddRange(TestData.ProjectManagerEntities);
        context.Statuses.AddRange(TestData.StatusEntities);
        context.Services.AddRange(TestData.ServiceEntities);
        context.Projects.AddRange(TestData.ProjectEntities);

        await context.SaveChangesAsync();
        IProjectRepository repository = new ProjectRepository(context);

        var projectId = TestData.ProjectEntities[0].Id;

        // Act
        var result = await repository.GetAsync(p => p.Id == projectId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(projectId, result!.Id);
        Assert.Equal(TestData.ProjectEntities[0].ProjectName, result.ProjectName);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProjects()
    {
        // Arrange
        var context = GetDataContext();
        context.Customers.AddRange(TestData.CustomerEntities);
        context.ProjectManagers.AddRange(TestData.ProjectManagerEntities);
        context.Statuses.AddRange(TestData.StatusEntities);
        context.Services.AddRange(TestData.ServiceEntities);
        context.Projects.AddRange(TestData.ProjectEntities);

        await context.SaveChangesAsync();
        IProjectRepository repository = new ProjectRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(TestData.ProjectEntities.Length, result.Count());
    }
    [Fact]
    public async Task UpdateAsync_ShouldUpdateProjectAndReturnTrue()
    {
        // Arrange
        var context = GetDataContext();
        context.Customers.AddRange(TestData.CustomerEntities);
        context.ProjectManagers.AddRange(TestData.ProjectManagerEntities);
        context.Statuses.AddRange(TestData.StatusEntities);
        context.Services.AddRange(TestData.ServiceEntities);

        await context.SaveChangesAsync();
        IProjectRepository repository = new ProjectRepository(context);

        var projectEntity = TestData.ProjectEntities[0];
        projectEntity.Description = "Updated Description";

        // Act
        var result = await repository.UpdateAsync(projectEntity);

        // Assert
        Assert.True(result);
        var updatedProject = await context.Projects.FindAsync(projectEntity.Id);
        Assert.NotNull(updatedProject);
        Assert.Equal("Updated Description", updatedProject!.Description);
    }
    [Fact]
    public async Task RemoveAsync_ShouldDeleteProjectAndReturnTrue()
    {
        // Arrange
        var context = GetDataContext();
        context.Customers.AddRange(TestData.CustomerEntities);
        context.ProjectManagers.AddRange(TestData.ProjectManagerEntities);
        context.Statuses.AddRange(TestData.StatusEntities);
        context.Services.AddRange(TestData.ServiceEntities);

        await context.SaveChangesAsync();
        IProjectRepository repository = new ProjectRepository(context);

        var projectEntity = TestData.ProjectEntities[0];

        // Act
        var result = await repository.RemoveAsync(projectEntity);

        // Assert
        Assert.True(result);
        var deletedProject = await context.Projects.FindAsync(projectEntity.Id);
        Assert.Null(deletedProject);
    }



}
