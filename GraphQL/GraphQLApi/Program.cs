using GraphQLApi.Repsoitory;
using GraphQLApi.Schema;
using GraphQLApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();
builder.Services.AddPooledDbContextFactory<CvDbContext>(opt => 
    opt.UseSqlite("Data Source=CvDb.db"));
builder.Services.AddScoped<CvRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();

app.MapGraphQL();

app.Run();