using Cloudweather.Pricipitation.DataAcces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PrecipDbContext>(
        opts=>
        {
            opts.EnableSensitiveDataLogging();
            opts.EnableDetailedErrors();
            opts.UseNpgsql(builder.Configuration.GetConnectionString("AppDb"));
        }, ServiceLifetime.Transient
    );
var app = builder.Build();


app.MapGet("/obsevation/{zip}", async (string zip, [FromQuery] int? days, PrecipDbContext db) =>
{
    if (days == null || days < 1 || days > 30)
    {
        return Results.BadRequest("Please provide the proper days number");
    }

    var startDate = DateTime.UtcNow - TimeSpan.FromDays(days.Value);
    var results = await db.Pricipitation.Where(precip => precip.ZipCode == zip && precip.CreatedOn > startDate).ToListAsync();
    return Results.Ok(results);

});

app.Run();
