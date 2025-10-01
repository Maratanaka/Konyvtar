using Konyvtar.Data;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

// Register DbContext with connection string from appsettings.json
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseMySQL(configuration.GetConnectionString("DefaultConnection"))
);

// Add controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- CORS hozzáadása ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVue",
        policy => policy
            .WithOrigins("http://localhost:5174") // Vue dev szerver
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});

var app = builder.Build();

// --- Use CORS ---
app.UseCors("AllowVue");

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
