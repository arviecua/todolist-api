using Microsoft.EntityFrameworkCore;
using todolist_api.Context;

var builder = WebApplication.CreateBuilder(args);

var policyName = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

// EF CORE
builder.Services.AddDbContext<MainDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MAIN_DB")));

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                      builder =>
                      {
                          builder
                            //.WithOrigins("http://superspeed-svr:8099")
                            .AllowAnyOrigin()
                            //.SetIsOriginAllowed(origin => true)
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                      });
});


var app = builder.Build();

// CORS
app.UseCors(policyName);

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
