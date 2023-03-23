using TaskProject.DAL.Repositories.Abstact;
using TaskProject.LairLogic;
using TaskProject.DAL.Repositories.Mock;
using TaskProject.DAL.Repositories.Mock.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<IUserRepository, UserMockRepository>();
builder.Services.AddScoped<ITaskRepository, TaskMockRepository>();

builder.Services.AddScoped<TaskListService>();

builder.Services.AddSingleton<UserMockData>();
builder.Services.AddSingleton<TaskMockData>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<UserService>();

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
