using HNews.API.Service;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

//Adding HTTPService HNews
var config = builder.Configuration;

builder.Services.AddHttpClient<HackerNewsApiService>(client =>
{
    client.BaseAddress = new Uri(config["HackerNewsApiSettings:BaseUrl"]);
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var corsRules = "CorsRules";

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: corsRules, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors(corsRules);

app.UseAuthorization();

app.MapControllers();

app.Run();
