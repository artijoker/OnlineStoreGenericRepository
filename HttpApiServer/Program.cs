using Microsoft.EntityFrameworkCore;
using HttpApiServer;
using HttpModels;


var builder = WebApplication.CreateBuilder(args);

var dbPath = "DbOnlineStore/myapp.db";
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlite($"Data Source={dbPath}")
    );

builder.Services.AddSingleton<IClock, Clock>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddScoped<CatalogService>();
builder.Services.AddScoped<AccountService>();

builder.Services.AddCors();
builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(policy =>
{
    policy
     .AllowAnyMethod()
     .AllowAnyHeader()
     .WithOrigins("https://localhost:7139")
     .AllowCredentials();
});
app.MapControllers();
app.MapGet("/", () => "Сервер работает");

app.Run();
