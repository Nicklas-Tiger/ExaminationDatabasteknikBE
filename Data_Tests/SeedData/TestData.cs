using Data.Entities;

namespace Datatests.Tests.SeedData;

public static class TestData
{
    public static readonly CustomerTypeEntity[] CustomerTypeEntities =
    [
        new CustomerTypeEntity { Id = 1, TypeName = "Företag" },
        new CustomerTypeEntity { Id = 2, TypeName = "Privatperson" }
    ];
    public static readonly CustomerEntity[] CustomerEntities =
    [
    new CustomerEntity { Id = 1, CustomerName = "TigerData AB", Email = "info@tigerdata.se", CustomerTypeId = 1, CustomerType = CustomerTypeEntities[0], Projects = [] },
    new CustomerEntity { Id = 2, CustomerName = "WebbTigern AB", Email = "info@webbtigern.se", CustomerTypeId = 1, CustomerType = CustomerTypeEntities[0], Projects = [] },
    new CustomerEntity { Id = 3, CustomerName = "TigerOnline AB", Email = "info@tigeronline.se", CustomerTypeId = 2, CustomerType = CustomerTypeEntities[1], Projects = [] },
    new CustomerEntity { Id = 4, CustomerName = "Djungelkonsulten", Email = "info@djungelkonsulten.se", CustomerTypeId = 2, CustomerType = CustomerTypeEntities[1], Projects = [] }
    ];

    public static readonly EmployeeEntity[] EmployeeEntities =
    [
        new EmployeeEntity { Id = 1, FirstName = "Nicklas", LastName = "Tiger", Email = "nicklas@tiger.se", Role = "VD" },
        new EmployeeEntity { Id = 2, FirstName = "Filip", LastName = "Tiger", Email = "filip@tiger.se", Role = "Vice VD" },
        new EmployeeEntity { Id = 3, FirstName = "Leon", LastName = "Tiger", Email = "leon@tiger.se", Role = "Vice VD" },
        new EmployeeEntity { Id = 4, FirstName = "Oliver", LastName = "Tiger", Email = "oliver@tiger.se", Role = "Vice VD"  },
    ];

    public static readonly ProjectManagerEntity[] ProjectManagerEntities =
    [
        new ProjectManagerEntity { Id = 1, FirstName = "Nicklas", LastName = "Tiger", Email = "nicklas@tiger.se" },
        new ProjectManagerEntity { Id = 2, FirstName = "Filip", LastName = "Tiger", Email = "filip@tiger.se" },
        new ProjectManagerEntity { Id = 3, FirstName = "Leon", LastName = "Tiger", Email = "leon@tiger.se" },
        new ProjectManagerEntity { Id = 4, FirstName = "Oliver", LastName = "Tiger", Email = "oliver@tiger.se" },
    ];

    public static readonly ServiceEntity[] ServiceEntities =
[
    new ServiceEntity { Id = 1, ServiceName = "Konsult Frontend" },
        new ServiceEntity { Id = 2, ServiceName = "Konsult Backend" },
        new ServiceEntity { Id = 3, ServiceName = "Hemsidepaket" },
    ];
    public static readonly StatusEntity[] StatusEntities =
[
    new StatusEntity { Id = 1, StatusName = "Ej påbörjad" },
        new StatusEntity { Id = 2, StatusName = "Pågår" },
        new StatusEntity { Id = 3, StatusName = "Avslutad" },
    ];
    public static readonly ProjectEntity[] ProjectEntities =
    [
        new ProjectEntity { ProjectName = "Cold Harbor", Description = "Rebuild Gemma", 
            StartDate = new DateTime(2025, 01, 01), EndDate = new DateTime(2025, 02, 25), 
            StatusId = StatusEntities![2].Id, CustomerId = CustomerEntities![0].Id, ProjectManagerId = ProjectManagerEntities![1].Id, ServiceId = ServiceEntities![0].Id },
        new ProjectEntity { ProjectName = "Tumwater", Description = "A historic location",
            StartDate = new DateTime(2025, 01, 01), EndDate = new DateTime(2025, 02, 11), 
            StatusId = StatusEntities![2].Id, CustomerId = CustomerEntities![2].Id, ProjectManagerId = ProjectManagerEntities![2].Id, ServiceId = ServiceEntities![1].Id },
        new ProjectEntity { ProjectName = "Lexington" , Description = "The Lexington letters", 
            StartDate = new DateTime(2025, 04, 01), EndDate = new DateTime(2025, 05, 31), 
            StatusId = StatusEntities![0].Id, CustomerId = CustomerEntities![3].Id, ProjectManagerId = ProjectManagerEntities![0].Id, ServiceId = ServiceEntities![0].Id },
        new ProjectEntity { ProjectName = "Moonbeam", Description = "Shine as the moon", 
            StartDate = new DateTime(2025, 03, 01), EndDate = new DateTime(2025, 03, 31), 
            StatusId = StatusEntities![0].Id, CustomerId = CustomerEntities![3].Id, ProjectManagerId = ProjectManagerEntities![3].Id, ServiceId = ServiceEntities![1].Id },
        new ProjectEntity { ProjectName = "Pacoima", Description = "How about those pacoimas?", 
            StartDate = new DateTime(2025, 03, 01), EndDate = new DateTime(2025, 03, 31), 
            StatusId = StatusEntities ![0].Id, CustomerId = CustomerEntities ![3].Id, ProjectManagerId = ProjectManagerEntities ![1].Id, ServiceId = ServiceEntities ![2].Id },
        new ProjectEntity { ProjectName = "The Siena File", Description = "The one and only", 
            StartDate = new DateTime(2025, 03, 01), EndDate = new DateTime(2025, 03, 31), 
            StatusId = StatusEntities ![1].Id, CustomerId = CustomerEntities ![2].Id, ProjectManagerId = ProjectManagerEntities ![2].Id, ServiceId = ServiceEntities ![2].Id },

    ];

}
