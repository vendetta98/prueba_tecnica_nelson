using backendC_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<nombre_apellido_dbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conex"));
});

builder.Services.AddCors(options => {
    options.AddPolicy("Front", policy => {
        policy.WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

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

app.UseCors("Front");

app.Run();
