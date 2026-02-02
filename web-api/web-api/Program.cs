using infra;
using Microsoft.EntityFrameworkCore;
using application;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Development");


builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString)
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "api");
            c.RoutePrefix = "swagger";
        });
    }

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
