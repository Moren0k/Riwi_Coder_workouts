using Microsoft.EntityFrameworkCore;
using WebSchool.Application.Interfaces;
using WebSchool.Application.Services;
using WebSchool.Domain.Interfaces;
using WebSchool.Infrastructure.Data;
using WebSchool.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection"); //Get connection string from AppSettings.json

// Add services to the container.
builder.Services.AddScoped<IStudentService, StudentService>(); //Student
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<ICourseRepository, CourseRepository>(); //Course
builder.Services.AddScoped<ICourseService, CourseService>();


//builder.Services.AddScoped<IInscriptionRepository, InscriptionRepository>(); //Inscription
//builder.Services.AddScoped<IInscriptionService, IInscriptionService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))); //Configuration of the DB context

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Test the connection to the database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        db.Database.OpenConnection();
        Console.WriteLine("Connection to database successful.");
        db.Database.CloseConnection();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error of connection: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();