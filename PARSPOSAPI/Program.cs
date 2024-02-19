using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using ParsPOS.DataAccess.IRepository;
using ParsPOS.DataAccess.Repository;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbConnection>((sp) =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var connectionString = config.GetConnectionString("DefaultConnection");
    return new SqlConnection(connectionString);
});
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddDirectoryBrowser();
var app = builder.Build();
var env = builder.Environment;

// Configure the HTTP request pipeline.

if (env.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//var reportsFolderPath = Path.Combine(env.ContentRootPath, "ParsAcc.Services", "Report");
////logger.LogInformation($"Reports folder path: {reportsFolderPath}");

//app.UseStaticFiles(new StaticFileOptions
//{
//	FileProvider = new PhysicalFileProvider(reportsFolderPath),
//	RequestPath = "/Report"
//});

//app.UseDirectoryBrowser();


//#if !DEBUG
//app.UseHttpsRedirection();
//#endif
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
