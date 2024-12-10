using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OpenAiVideoSummary.Api.Model;
using OpenAiVideoSummary.Api.Repository;
using OpenAiVideoSummary.Api.Service;


var builder = WebApplication.CreateBuilder(args);

// Add database settings
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));

// Add services to the container.
builder.Services.AddSingleton<VideoRepository>();
builder.Services.AddSingleton<ChannelRepository>();
builder.Services.AddSingleton<VideoService>();
builder.Services.AddSingleton<ChannelService>();
builder.Services.AddSingleton<IChannelService, ChannelService>();
builder.Services.AddSingleton<IVideoService, VideoService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
