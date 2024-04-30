using Microsoft.EntityFrameworkCore;
using Olih.Infrastructure;
using Olih.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureService();


builder.Services.AddDbContextFactory<OlihDbContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("OlibDb")));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();