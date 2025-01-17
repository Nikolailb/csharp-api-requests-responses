using exercise.wwwapi.Data;
using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGenericRepository<Student>, StudentRepository>();
builder.Services.AddScoped<IGenericRepository<Language>, LanguageRepository>();
builder.Services.AddScoped<IGenericRepository<Book>, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapSwagger();
    app.MapScalarApiReference();
}

StudentCollection.Initialize();
LanguageCollection.Initialize();
BookCollection.Initialize();

app.UseHttpsRedirection();

app.ConfigureStudentEndpoint();
app.ConfigureLanguageEndpoint();
app.ConfigureBookEndpoint();

app.Run();

