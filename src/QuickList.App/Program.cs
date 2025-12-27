using Microsoft.EntityFrameworkCore;
using QuickList.App.Endpoints;
using QuickList.App.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();

app.MapTodoEndpoints();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

