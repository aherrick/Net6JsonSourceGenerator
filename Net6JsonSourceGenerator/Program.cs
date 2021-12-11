using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.AddContext<VenueJsonContext>();
});

app.MapGet($"GetVenues", () =>
{
    var venues = new List<Venue>();

    return venues;
});

app.Run();

public class Venue
{
    public string Name { get; set; }

    [JsonIgnore]
    public Geometry Location { get; set; }
}

[JsonSerializable(typeof(Venue[]))]
public partial class VenueJsonContext : JsonSerializerContext
{
}