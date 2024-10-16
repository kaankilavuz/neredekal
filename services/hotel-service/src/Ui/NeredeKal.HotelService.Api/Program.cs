using NeredeKal.HotelService.Api.Middlewares;
using NeredeKal.HotelService.Application.DIs;
using NeredeKal.HotelService.Persistence.DIs;
using NeredeKal.HotelService.Persistence.EntityFrameworkCore.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddEntityFrameworkCore()
    .AddUnitOfWork()
    .AddRepositories();

builder.Services.AddMediatR()
    .AddProfiles();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

