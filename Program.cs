using BudgetTracker.Data;
using BudgetTracker.Data.DataBase;
using BudgetTracker.Models;
using BudgetTracker.Repositories;
using BudgetTracker.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var myPolicy = "MyPolicy";

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myPolicy, builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .WithOrigins("http://127.0.0.1:5500/index.html", "http://127.0.0.1:5500", "http://localhost:5500");
    });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<BudgetTrackerContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("localDb")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myPolicy);

app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<BudgetTrackerContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

try
{
    context.Database.Migrate();
    DBInitializer.Initialize(context);
}
catch(Exception ex)
{
    logger.LogError(ex, "Problem migrating data");
}

app.Run();
