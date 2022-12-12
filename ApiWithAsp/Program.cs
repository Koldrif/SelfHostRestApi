using NLog;
using NLog.Web;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

var logger = NLog.LogManager.Setup().LoadConfigurationFromFile(configFile: @"F:\Work\I-teco\Задания\RestApi\ApiWithAsp\Properties\nlog.config").GetCurrentClassLogger();
logger.Info("Init main");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Host.UseNLog();
// builder.Logging.AddConsole();

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

app.Use(async (context, next) =>
{
    var logMessage = $"Request\t{context.Connection.Id} from:\t{context.Connection.RemoteIpAddress}";
    app.Logger.Log(LogLevel.Information, logMessage);
    await next();
    logMessage = $"Response\t{context.Connection.Id} sent to {context.Response.HttpContext.Connection.RemoteIpAddress} with status code {context.Response.StatusCode}";
    app.Logger.Log(LogLevel.Information, logMessage);
});

app.Run();