using Microsoft.EntityFrameworkCore;
using Api.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// DbContext 
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseNpgsql("Host=ep-tiny-cake-agx7v3eu-pooler.c-2.eu-central-1.aws.neon.tech;Username=neondb_owner;Password=npg_SIGPlrcOy4k8;Database=neondb;SSL Mode=Require;Trust Server Certificate=true"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoint 
app.MapGet("/", () => "Library API is running");

// Controllers
app.MapControllers();

//  seeding
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
    DbInitializer.Seed(db);
}

app.Run();