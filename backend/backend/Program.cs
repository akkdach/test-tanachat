using backend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
var connection = builder.Configuration["ConnectionString"];

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connection)
);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
           b => b.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod()
           );
    options.AddPolicy("DevPolicy", b =>
         b.AllowAnyHeader()
         .AllowAnyOrigin()
         .AllowAnyMethod()
    );
});


var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
