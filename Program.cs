using Graph_Demo;
using Graph_Demo.Repositories;
using Graph_Demo.Settings;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System.Net.Mime;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var mdbSettings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();

BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

builder.Services.AddSingleton<IMongoClient>(ServiceProvider => new MongoClient(mdbSettings.ConnectionString));
builder.Services.AddSingleton<IBooksRepository, MDBBooksRepo>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();
builder.Services.AddHealthChecks().AddMongoDb(mdbSettings.ConnectionString,
 name: "MongoDB", timeout: TimeSpan.FromSeconds(3), tags: new[] { "Ready" });
var app = builder.Build();

app.MapGraphQL();
app.MapHealthChecks("/health/ready", new HealthCheckOptions()
{
    Predicate = (check) => check.Tags.Contains("Ready"),
    ResponseWriter = async (context, report) =>
    {
        var result = JsonSerializer.Serialize(new
        {
            status = report.Status.ToString(),
            checks = report.Entries.Select(entry => new
            {
                name = entry.Key,
                status = entry.Value.Status.ToString(),
                exeption = entry.Value.Exception?.Message ?? null,
                duration = entry.Value.Duration.ToString(),
            })
        });
        context.Response.ContentType = MediaTypeNames.Application.Json;
        await context.Response.WriteAsync(result);
    }
});
app.MapHealthChecks("/health/live", new HealthCheckOptions() { Predicate = (_) => false });
app.Run();
