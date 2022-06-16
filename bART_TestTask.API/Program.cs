using Autofac;
using Autofac.Extensions.DependencyInjection;
using bART_TestTask.BLL.Configurations.Autofac;
using bART_TestTask.DAL.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("LocalConnection");

builder.Services.AddDbContext<TestTaskContext>(options => options
    .UseSqlServer(connectionString, b => b.MigrationsAssembly("bART_TestTask.DAL"))
    .EnableSensitiveDataLogging(), ServiceLifetime.Transient);


// Add services to the container.

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new Container());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
