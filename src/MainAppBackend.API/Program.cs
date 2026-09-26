using MainAppBackend.Application.Interfaces.ClientLookup;
using MainAppBackend.Application.Interfaces.Product;
using MainAppBackend.Application.Services.ClientLookup;
using MainAppBackend.Application.Services.Product;
using MainAppBackend.Domain.Entities.ClientLookup;
using MainAppBackend.Domain.Interfaces.Product;
using MainAppBackend.Infrastructure.Persistence;
using MainAppBackend.Infrastructure.Repositories.ClientLookup;
using MainAppBackend.Infrastructure.Repositories.Product;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(cfg => { },
    typeof(Program).Assembly,
    typeof(ProductCategoryService).Assembly); // <-- scans MainAppBackend.Application too

builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IClientLookupService, ClientLookupService>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IClientLookupRepository, ClientLookupRepository>();

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