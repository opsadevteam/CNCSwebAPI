using CNCSapi.Interface;
using CNCSapi.Repository;
using CNCSproject.Interface;
using CNCSproject.Repository;
using CNCSwebApiProject.Interface;
using CNCSwebApiProject.Models;
using CNCSwebApiProject.Repository;
using CNCSwebApiProject.Services.ActivityLogService;
using CNCSwebApiProject.Services.DescriptionService;
using CNCSwebApiProject.Services.ProductVendorService;
using CNCSwebApiProject.Services.TransactionService;
using CNCSwebApiProject.Services.WorkloadStatistics;
using CNCSwebApiProject.Services.UserAccountService;

using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CncssystemContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IEmailRecordsRepository, EmailRecordsRepository>();
builder.Services.AddScoped<IPhoneRecordsRepository, PhoneRecordsRepository>();
builder.Services.AddScoped<ITransactionLogsRepository, TransactionLogsRepository>();
builder.Services.AddScoped<IWorkloadStatisticsService, WorkloadStatisticsService>();
builder.Services.AddScoped<IProductVendorRepository, ProductVendorRepository>();
builder.Services.AddScoped<IProductVendorService, ProductVendorService>();
builder.Services.AddScoped<IDescriptionRepository, DescriptionRepository>();
builder.Services.AddScoped<IDescriptionService, DescriptionService>();
builder.Services.AddScoped<IUserAccountRepository, UserAccountRepository>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();
builder.Services.AddScoped<IActivityLogRepository, ActivityLogRepository>();
builder.Services.AddScoped<IActivityLogService, ActivityLogService>();

builder.Services.AddScoped<IProductVendorRepositoryNew, ProductVendorRepositoryNew>();
builder.Services.AddScoped<IProductVendorServiceNew, ProductVendorServiceNew>();

builder.Services.AddScoped<IProductDescriptionRepository, ProductDescriptionRepository>();
builder.Services.AddScoped<IProductDescriptionService, ProductDescriptionService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
// my Cors
app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
