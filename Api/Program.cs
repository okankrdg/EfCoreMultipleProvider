using Data;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Api.Extensions;
using Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("UserContext"), x => x.MigrationsAssembly("Data"))
    );
builder.Services.AddDbContext<BookContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("BookContext"), x => x.MigrationsAssembly("Data")));
builder.Services.ExecuteMigrations();
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

app.MapGet("/user-insert", (UserContext context) =>
{
    context.Users.Add(new User { Name = "Banu" });
    context.SaveChanges();
    return Results.Ok();
});

app.Run();
