using Microsoft.EntityFrameworkCore;
using Api.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// DbContext
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseNpgsql("Host=ep-tiny-cake-agx7v3eu-pooler.c-2.eu-central-1.aws.neon.tech;Username=neondb_owner;Password=npg_SIGPlrcOy4k8;Database=neondb;SSL Mode=Require;Trust Server Certificate=true"));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//  CORS 
app.UseCors("AllowFrontend");

using (var scope = app.Services.CreateScope())
{
    var books = scope.ServiceProvider.GetRequiredService<LibraryDbContext>().Books.ToList();
    Console.WriteLine(books.Count);
}

// Controllers
app.MapControllers();

// check endpoint
app.MapGet("/", () => "Library API is running");

// Seeding
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
    DbInitializer.Seed(db);
}

app.Run();