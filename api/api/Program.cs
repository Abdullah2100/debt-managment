using business;
using data;
using data.UnitOfWork;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionUrl = builder.Configuration.GetConnectionString("connection_url");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionUrl??""));

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.UseRouting();

app.Run();

 