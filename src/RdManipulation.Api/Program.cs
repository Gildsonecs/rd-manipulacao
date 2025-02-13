using Microsoft.EntityFrameworkCore;
using RdManipulation.Application.Services.Commands;
using RdManipulation.Domain.Interfaces;
using RdManipulation.Infra.Data.Contexts;
using RdManipulation.Infra.Data.Repositories;
using RdManipulation.Infra.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateVideoCommand).Assembly));

builder.Services.AddHttpClient<YouTubeApiService>();

// Adiciona o DbContext usando SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Adiciona controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IVideoRepository, VideoRepository>();

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
