using KolokwiumApbdNumer2.Data;
using Microsoft.EntityFrameworkCore;

using KolokwiumApbdNumer2.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IDbservice, DbService>();


builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer("Server=localhost,1434;Database=TournamentDb;User Id=SA;Password=Passw0rd??;TrustServerCertificate=True"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();
app.Run();