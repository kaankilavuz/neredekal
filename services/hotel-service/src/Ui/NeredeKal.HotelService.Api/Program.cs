using NeredeKal.HotelService.Api.Routers.Hotels;
using NeredeKal.HotelService.Application.DIs;
using NeredeKal.HotelService.Persistence.EntityFrameworkCore.DIs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkCore().AddUnitOfWork().AddRepositories();
builder.Services.AddMediatR();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
HotelRouter.MapHotelRoutes(app);
app.Run();
