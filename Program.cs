using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Hämta connectionstring. 
string? connectionString = builder.Configuration.GetConnectionString("DbConnection");

// Lägga till databasen i DependencyInjection Container
// SOLID - D / DEPDENCY INVERSION PRINCIPLE.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


// 3 olika sätt att lägga till i DI container - med Repository Pattern
// 1. Transient
// - Livdstidenär per användning: ny instans på varje metod. ( Ny varje gång, en ny AppDbContext)
// 2. Scoped
// -- Livdstiden är per request: använder samma instans på metod. ( Ny en gång, sen samma AppDBcontext)
// 3. Singleton 
// ---  Det finns endast 1, lite som static. Livstiden är appens "run" / appens liv. (samma AppDbContext)

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
