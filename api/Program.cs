using api.Contexts;
using api.Interfaces.Repositories;
using api.Models;
using api.Repositories;
using Microsoft.AspNetCore.Mvc;
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

app.MapGet("/house/{houseId:int}", async (int houseId, IHouseRepository repository) =>
{
    var detail = await repository.GetDetail(houseId);
    if (detail == null)
    {
        return Results.Problem($"HouseId {houseId} does not exist.", statusCode: 404);
    }

    return Results.Ok(detail);
}).ProducesProblem(404).Produces<HouseDetail>(StatusCodes.Status200OK);

app.MapDelete("/houses/{houseId:int}", async (int houseId, IHouseRepository repository) =>
{
    if (await repository.GetDetail(houseId) == null)
    {
        return Results.Problem($"House Id {houseId} not found.", statusCode: 404);
    }

    await repository.Delete(houseId);

    return Results.Ok();
}).ProducesProblem(404).Produces(StatusCodes.Status200OK);

app.MapGet("/houses", (IHouseRepository repository) =>
{
    return repository.Get();
}).Produces<House[]>(StatusCodes.Status200OK);

app.MapPost("/houses", async ([FromBody]HouseDetail dto, IHouseRepository repository) =>
{
    var h = await repository.Add(dto);

    return Results.Created($"/house/{h.Id}", h);
}).Produces<HouseDetail>(StatusCodes.Status201Created);

app.MapPut("/houses", async ([FromBody]HouseDetail dto, IHouseRepository repository) =>
{
    if (await repository.GetDetail(dto.Id) == null)
    {
        return Results.Problem($"House Id {dto.Id} not found.", statusCode: 404);
    }

    var h = await repository.Update(dto);

    return Results.Ok(h);
}).ProducesProblem(404).Produces<HouseDetail>(StatusCodes.Status200OK);

app.Run();