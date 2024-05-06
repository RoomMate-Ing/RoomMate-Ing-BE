using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks.Dataflow;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using DAL.IRepositories;
using DAL.Repositories;
using BLL_Service.Interface;
using BLL_Service.Service;

var builder = WebApplication.CreateBuilder(args);


// Get the actual enviroment
var env = builder.Environment;

// Configure the right appsettings.json for the actual enviroment
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);


#region DB Configuration

// Get the connection string from the appsettings.json for the actual enviroment
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Add SqlLite Connection
builder.Services.AddDbContext<RoomMateDBContext>(
      options => options.UseSqlite(
         connectionString
      )
    );
#endregion
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IRoomateService, RoomateService>();
builder.Services.AddScoped<IHouseWorkService, HouseWorkService>();
builder.Services.AddScoped<IWorkShiftService, WorkShiftService>();

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
