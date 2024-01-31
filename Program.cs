using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// H�mta connectionstring. 
string? connectionString = builder.Configuration.GetConnectionString("DbConnection");

// L�gga till databasen i DependencyInjection Container
// SOLID - D / DEPDENCY INVERSION PRINCIPLE.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


// 3 olika s�tt att l�gga till i DI container - med Repository Pattern
// 1. Transient
// - Livdstiden�r per anv�ndning: ny instans p� varje metod. ( Ny varje g�ng, en ny AppDbContext)
// 2. Scoped
// -- Livdstiden �r per request: anv�nder samma instans p� metod. ( Ny en g�ng, sen samma AppDBcontext)
// 3. Singleton 
// ---  Det finns endast 1, lite som static. Livstiden �r appens "run" / appens liv. (samma AppDbContext)

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
