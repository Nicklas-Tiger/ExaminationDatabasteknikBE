using Business.Interfaces;
using Business.Services;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();


builder.Services.AddScoped<BaseRepository<CustomerAddressEntity>>();
builder.Services.AddScoped<BaseRepository<CustomerContactEntity>>();
builder.Services.AddScoped<BaseRepository<CustomerEntity>>();
builder.Services.AddScoped<BaseRepository<CustomerTypeEntity>>();
builder.Services.AddScoped<BaseRepository<DocumentEntity>>();
builder.Services.AddScoped<BaseRepository<EmployeeEntity>>();
builder.Services.AddScoped<BaseRepository<MeetingEntity>>();
builder.Services.AddScoped<BaseRepository<NoteEntity>>();
builder.Services.AddScoped<BaseRepository<PostalCodeEntity>>();
builder.Services.AddScoped<BaseRepository<ProjectEntity>>();
builder.Services.AddScoped<BaseRepository<ProjectHistoryEntity>>();
builder.Services.AddScoped<BaseRepository<ProjectManagerEntity>>();
builder.Services.AddScoped<BaseRepository<ServiceEntity>>();
builder.Services.AddScoped<BaseRepository<StatusEntity>>();
builder.Services.AddScoped<BaseRepository<TaskEntity>>();


builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IProjectManagerService, ProjectManagerService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IStatusCodeService, StatusCodeService>();




var app = builder.Build();
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
