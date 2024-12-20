using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OpenAiVideoSummary.Api.Model;
using OpenAiVideoSummary.Api.Repository;
using OpenAiVideoSummary.Api.Service;
using Microsoft.Extensions.Logging.AzureAppServices;

var builder = WebApplication.CreateBuilder(args);

// Add database settings
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));

// Add services to the container.

builder.Services.AddScoped<IBaseRepository<Video>, VideoRepository>();
builder.Services.AddScoped<IBaseRepository<Channel>, ChannelRepository>();
builder.Services.AddScoped<IVideoRepository<Video>, VideoRepository>();
builder.Services.AddScoped<IChannelService, ChannelService>();
builder.Services.AddScoped<IVideoService, VideoService>();


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddLogging();
builder.Logging.AddAzureWebAppDiagnostics();
builder.Services.Configure<AzureFileLoggerOptions>(options =>
{
    options.FileName = "azure-diagnostics-";
    options.FileSizeLimit = 50 * 1024;
    options.RetainedFileCountLimit = 5;
});


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:8081/");
                      });
});

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
