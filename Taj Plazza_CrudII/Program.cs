using Microsoft.EntityFrameworkCore;
using Taj_Plazza.Core.DataAcess;
using Taje__Plazza.Domain.Interface;
using Taje_Plazza.Application.Services;
using Taje_Plazza.Infrastructure.Repertory;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IClientRepertory, ClientRepertory>();
builder.Services.AddScoped<IClientServices,ClientServices>();
builder.Services.AddScoped<IEvenementRepertory, EvenementRepertory>();
builder.Services.AddScoped<IEvenementServices, EvenementServices>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);


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
