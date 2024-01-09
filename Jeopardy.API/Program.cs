using Jeopardy.Core.Data;
using Jeopardy.Core.Interfaces;
using Jeopardy.Core.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IClueRepository, ClueRepository>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options =>
{
    if (builder.Environment.IsProduction())
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
    else
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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