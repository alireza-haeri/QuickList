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

if (app.Environment.IsDevelopment())
{
    //Config Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
    
    //Auto Migration
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();