using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using MyEventsWatcher.Api.Models;
using MyEventsWatcher.Api.Services.Hosted;
using MyEventsWatcher.Shared;
using JsonSerializer = MyEventsWatcher.Shared.JsonSerializer;

//Create builder.
#region Builder
var builder = WebApplication.CreateBuilder(args);
#endregion


// Add services to the container.
#region Services
builder.Services.AddHostedService<EventsWatcher>();
builder.Services.Configure<AppConfig>(builder.Configuration.GetSection("AppConfig"));
builder.Services.AddTransient<IJsonSerializer, JsonSerializer>();
#endregion

//Add controllers and configure json options.
#region Controllers
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.DefaultBufferSize = 1500;
    options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Default;
    options.JsonSerializerOptions.AllowTrailingCommas = false;
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});
#endregion

//Configure access to application database.     
#region EntityFramework
/*
services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(dbConnectionString));
*/

#endregion

//Configure access to Orion.
#region OrionHttpClients

builder.Services.AddHttpClient("Entities",
    client =>
    {
        client.BaseAddress = new Uri(builder.Configuration.GetSection("AppConfig:entities")
            .Get<string>());
        client.DefaultRequestHeaders.Add("User-Agent", "MyEventsWatcher-Api");
        
    });

builder.Services.AddHttpClient("Entities-Relationship",
    client =>
    {
        client.BaseAddress = new Uri(builder.Configuration.GetSection("AppConfig:relationship")
            .Get<string>());
        client.DefaultRequestHeaders.Add("User-Agent", "MyEventsWatcher-Api");
        
    });

builder.Services.AddHttpClient("DiscoveryApi",
    client =>
    {
        client.BaseAddress = new Uri(builder.Configuration.GetSection("AppConfig:discoveryBaseUri")
            .Get<string>());
        client.DefaultRequestHeaders.Add("User-Agent", "MyEventsWatcher-Api");
    }).ConfigurePrimaryHttpMessageHandler(() =>
{
    //Handler pour encapsuler l'authentification NTLM avec les credentials de l'utilisateur windows
    return new HttpClientHandler
    {
        UseDefaultCredentials = false,
        AllowAutoRedirect = true,
        //Pour la future prise en charge de ssl, sert � n�gocier le handshake avec le serveur pour les requ�tes
        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
    };
}).SetHandlerLifetime(TimeSpan.FromMinutes(30));

builder.Services.AddHttpClient("Events",
    client =>
    {
        client.BaseAddress = new Uri(builder.Configuration.GetSection("AppConfig:events")
            .Get<string>());
        client.DefaultRequestHeaders.Add("User-Agent", "MyEventsWatcher-Api");
    }).ConfigurePrimaryHttpMessageHandler(() =>
{
    //Handler pour encapsuler l'authentification NTLM avec les credentials de l'utilisateur windows
    return new HttpClientHandler
    {
        UseDefaultCredentials = false,
        AllowAutoRedirect = true,
        //Pour la future prise en charge de ssl, sert � n�gocier le handshake avec le serveur pour les requ�tes
        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
    };
}).SetHandlerLifetime(TimeSpan.FromMinutes(30));

builder.Services.AddHttpClient("Venues",
    client =>
    {
        client.BaseAddress = new Uri(builder.Configuration.GetSection("AppConfig:venues")
            .Get<string>());
        client.DefaultRequestHeaders.Add("User-Agent", "MyEventsWatcher-Api");
    }).ConfigurePrimaryHttpMessageHandler(() =>
{
    //Handler pour encapsuler l'authentification NTLM avec les credentials de l'utilisateur windows
    return new HttpClientHandler
    {
        UseDefaultCredentials = false,
        AllowAutoRedirect = true,
        //Pour la future prise en charge de ssl, sert � n�gocier le handshake avec le serveur pour les requ�tes
        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
    };
}).SetHandlerLifetime(TimeSpan.FromMinutes(30));


builder.Services.AddHttpClient("Subscriptions",
    client =>
    {
        client.BaseAddress = new Uri(builder.Configuration.GetSection("AppConfig:subscriptions")
            .Get<string>());
        client.DefaultRequestHeaders.Add("User-Agent", "MyEventsWatcher-Api");
    }).ConfigurePrimaryHttpMessageHandler(() =>
{
    //Handler pour encapsuler l'authentification NTLM avec les credentials de l'utilisateur windows
    return new HttpClientHandler
    {
        UseDefaultCredentials = false,
        AllowAutoRedirect = true,
        //Pour la future prise en charge de ssl, sert � n�gocier le handshake avec le serveur pour les requ�tes
        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
    };
}).SetHandlerLifetime(TimeSpan.FromMinutes(30));
#endregion


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
#region Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

//Configure the web application.
#region WebApplication
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
