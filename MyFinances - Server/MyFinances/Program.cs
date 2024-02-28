using Microsoft.EntityFrameworkCore;
using MyFinances.Domain.Data;
using MyFinances.Domain.Mappers;
using MyFinances.Repository.Interfaces;
using MyFinances.Repository.Repositorys;
using MyFinances.Service.Interfaces;
using MyFinances.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:8080") // Adjust the origin to match your client application
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(FinancialTransactionMapper));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IFinancialTransactionRepository, FinancialTransactionRepository>();
builder.Services.AddScoped<IFinancialTransactionService, FinancialTransactionService>();

//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.MapControllers();
app.Run();
