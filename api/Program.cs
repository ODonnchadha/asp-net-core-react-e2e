using api.Contexts;
using api.Interfaces.Repositories;
using api.Models;
using api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<HouseDbContext>(context => {
    context.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddScoped<IHouseRepository, HouseRepository>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(
    c => c.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());
app.UseHttpsRedirection();

app.MapGet("/houses", (IHouseRepository repository) =>
{
    return repository.Get();
}).Produces<House[]>(StatusCodes.Status200OK);;

app.MapGet("/house/{houseId:int}", async (int houseId, IHouseRepository repository) =>
{
    var detail = await repository.GetDetail(houseId);
    if (detail == null)
    {
        return Results.Problem($"HouseId {houseId} does not exist.", statusCode: 404);
    }
    return Results.Ok(detail);
}).ProducesProblem(404).Produces<HouseDetail>(StatusCodes.Status200OK);

app.Run();