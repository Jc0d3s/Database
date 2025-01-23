using Web.Data;  // Your DbContext namespace
using Web.Models; // Your repository namespace for models
using Microsoft.EntityFrameworkCore;
using Web.Controllers;  // For DbContext and SQL Server

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext with SQL Server (replace with your connection string)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add repository services (replace with actual repository interfaces and implementations)
builder.Services.AddScoped<ContactDetailsController, ContactDetailsController>();
builder.Services.AddScoped<HeaderSectionController, HeaderSectionController>();
builder.Services.AddScoped<LogosController, LogosController>();
builder.Services.AddScoped<MenuController, MenuController>();
builder.Services.AddScoped<NavbarController, NavbarController>();
builder.Services.AddScoped<NewsController, NewsController>();
builder.Services.AddScoped<ServicesController, ServicesController>();
builder.Services.AddScoped<TeamController, TeamController>();
builder.Services.AddScoped<TestimonialsController, TestimonialsController>();

// Optionally, you can add singleton or scoped services for other dependencies
// Example: builder.Services.AddSingleton<DbConnection>(); if needed for custom connections.

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
