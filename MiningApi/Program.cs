using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MiningDataAccessLayer;
using MiningDataAccessLayer.Interfaces;
using MiningDataAccessLayer.MemoryBased;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Register our DAO class for getting customer objects
//AddScoped to have a new instance for each request

//builder.Services.AddSingleton<IMiningGameDao, InMemoryGameDao>();
//builder.Services.AddSingleton<IAuctionDao, InMemoryAuctionDao>();
//builder.Services.AddSingleton<ITeamDao, InMemoryTeamDao>();

builder.Services.AddSingleton<IMiningGameDao>(_ => TestDataCreator.MiningGameDao);
builder.Services.AddSingleton<IAuctionDao>(_ => TestDataCreator.AuctionDao);
builder.Services.AddSingleton<ITeamDao>(_ => TestDataCreator.TeamDao);


//builder.Services.AddSingleton<IMapSquareDao, InMemoryMapSquareDao>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHttpLogging();
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
