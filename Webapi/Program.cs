using Microsoft.EntityFrameworkCore;
using Models.Model;
using Webapi.Controllers;
using AutoMapper;
using DAL.Interface;
using DAL.DTO;

using DAL.Implementation;


string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(op =>
{
    op.AddPolicy(MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<ProjectCotext>(op => op.UseSqlServer("Data Source=DESKTOP-SI8MC0H;Initial Catalog=AmericalTable;Integrated Security=true;Trusted_Connection=True;TrustServerCertificate=True;"));


builder.Services.AddScoped<IDonation, DonationService>();
builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
