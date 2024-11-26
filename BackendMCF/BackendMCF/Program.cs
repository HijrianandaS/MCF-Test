using BackendMCF.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
//                           ?? "Server=CS-HIJRIANANDA;Database=mcf_db;Trusted_Connection=true;MultipleActiveResultSets=true;Encrypt=False;";
//    options.UseSqlServer(connectionString);
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//IMPLEMENTASI CORS
app.UseCors(options => options
.AllowAnyOrigin()
.AllowAnyHeader()
.AllowAnyMethod());
app.UseHttpsRedirection();

app.UseAuthentication(); // Menambahkan middleware autentikasi

app.UseAuthorization();

app.MapControllers();

//var envVariable = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
//Console.WriteLine($"Environment Variable Value: {envVariable}");


app.Run();
