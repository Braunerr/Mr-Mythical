using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;

using shared.Model;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Sætter CORS så API'en kan bruges fra andre domæner
var AllowSomeStuff = "_AllowSomeStuff";
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: AllowSomeStuff,
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
    );
});

// Tilføj DbContext factory som service.
builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("ContextSQLite"))
);

// Viser flotte fejlbeskeder i browseren hvis der kommer fejl fra databasen
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Tilføj DataService så den kan bruges i endpoints
builder.Services.AddScoped<DataService>();

// Dette kode kan bruges til at fjerne "cykler" i JSON objekterne.

builder.Services.Configure<JsonOptions>(options =>
{
    // Her kan man fjerne fejl der opstår, når man returnerer JSON med objekter,
    // der refererer til hinanden i en cykel.
    // (altså dobbelrettede associeringer)
    options.SerializerOptions.ReferenceHandler = System
        .Text
        .Json
        .Serialization
        .ReferenceHandler
        .IgnoreCycles;
});

var app = builder.Build();

//Seed data hvis nødvendigt.
using (var scope = app.Services.CreateScope())
{
    var dataService = scope.ServiceProvider.GetRequiredService<DataService>();
    dataService.SeedData();
}

app.UseHttpsRedirection();
app.UseCors(AllowSomeStuff);

// Middlware der kører før hver request. Sætter ContentType for alle responses til "JSON".
app.Use(
    async (context, next) =>
    {
        context.Response.ContentType = "application/json; charset=utf-8";
        await next(context);
    }
);

app.Run();