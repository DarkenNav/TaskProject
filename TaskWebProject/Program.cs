using Microsoft.EntityFrameworkCore;
using TaskProject.DAL.EF;
using TaskProject.DAL.EF.Repositories;
using TaskProject.DAL.Repositories.Mock;
using TaskProject.DAL.Repositories.Mock.Data;
using TaskProject.DAL.Repositories.Postgree;
using TaskProject.Domain.Repositories.Abstact;
using TaskProject.LairLogic;
using TaskWebProject.PostgresMigrate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<TaskListService>();
builder.Services.AddScoped<UserListService>();

var dbType = builder.Configuration["DbConfig:Type"];
switch (dbType)
{
    case "Postgres":
        var connectionString = builder.Configuration.GetConnectionString("NpgsqlConnectionString");
        PostgresMigrator.Migrate(connectionString);

        builder.Services.AddScoped<ITaskRepository, TaskPostgreeRepository>(x => new TaskPostgreeRepository(connectionString));
        builder.Services.AddScoped<IUserRepository, UserPostgreeRepository>(x => new UserPostgreeRepository(connectionString));
        break;
    case "Mock":
        builder.Services.AddSingleton<UserMockData>();
        builder.Services.AddSingleton<TaskMockData>();
        
        builder.Services.AddScoped<IUserRepository, UserMockRepository>();
        builder.Services.AddScoped<ITaskRepository, TaskMockRepository>();
        break;
    case "EF":
        var connectionStringEF = builder.Configuration.GetConnectionString("NpgsqlConnectionString");
        PostgresMigrator.Migrate(connectionStringEF);

        builder.Services.AddDbContext<PostgreeContext>(
            options => options.UseNpgsql(connectionStringEF));


        builder.Services.AddScoped<ITaskRepository, TaskEFPostgreeRepository>();
        builder.Services.AddScoped<IUserRepository, UserEFPostgreeRepository>();
        break;
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TaskList}/{action=Index}/{id?}");

app.Run();
