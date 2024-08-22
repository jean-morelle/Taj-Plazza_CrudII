using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Taj_Plazza.Core.DataAcess;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Repertory;
using Taj_Plazza.Core.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IClientRepertory,ClientRepertory>();
builder.Services.AddScoped<IClientServices,ClientServices>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//here is the url that's been granted access by the CORS policy (use web url address allowed )
app.UseCors(policy => policy.WithOrigins("https://localhost:7145")
.AllowAnyMethod()
.WithHeaders(HeaderNames.ContentType)
.AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
