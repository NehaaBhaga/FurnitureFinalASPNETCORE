using APICapstoneProject.Data;
using APICapstoneProject.Models;
using APICapstoneProject.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Inject DbContext Registration
builder.Services.AddDbContext<RegistrationsDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("OrganizationDbConnectionString")));

//Inject DbContext Order Request
builder.Services.AddDbContext<OrderRequestDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("OrganizationDbConnectionString")));

//Inject DbContext Vendor Table
builder.Services.AddDbContext<VendorTableDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("OrganizationDbConnectionString")));

// Inject DbContext Full Order Detail
builder.Services.AddDbContext<OrderDetailDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("OrganizationDbConnectionString")));


//Email
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService,MailService>();



builder.Services.AddCors((setup) =>
{
    setup.AddPolicy("default", (options) =>
    {
        options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
