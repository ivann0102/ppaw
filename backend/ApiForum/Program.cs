using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using NiveAccessDate_CodeFirst;
using Repository_CodeFirst;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
try{
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.AddDbContext<ForumContext>(
  options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("ForumContext"),
    b => b.MigrationsAssembly("ApiForum")
  ));
builder.Services.AddTransient<IPostsAccessor, PostsAccessor>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IUsersAccessor, UsersAccessor>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITopicsAccessor, TopicsAccessor>();
builder.Services.AddTransient<ITopicService, TopicService>();
builder.Services.AddTransient<ICache, CacheService>();

builder.Services.AddMemoryCache();
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
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}