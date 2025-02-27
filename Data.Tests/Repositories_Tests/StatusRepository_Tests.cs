using Data.Contexts;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tests.Repositories_Tests;

//public class StatusRepository_Tests
//{
//    [Fact]
//    public async Task AddAsync_ShouldAddStatus()
//    {
//        var context = DataContextSeeder.GetDataContext();
//        var statusRepository = new StatusRepository(context);

//        var result = await statusRepository.AddAsync(TestData.StatusTestData[0]);

//        Assert.Equal(1, result!.Id);
//    }
//}
