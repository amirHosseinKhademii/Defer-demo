using Graph_Demo;
using Graph_Demo.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IBooksRepository, BooksRepository>();
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>().AddMutationType<Mutation>();


var app = builder.Build();

app.MapGraphQL();

app.Run();
