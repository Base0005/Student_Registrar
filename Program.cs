using Registrar.Components;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Dapper;
using Registrar.Services;

var builder = WebApplication.CreateBuilder(args);

// Retrieve the connection string from environment variables
var connectionString = Environment.GetEnvironmentVariable("JAWSDB_URL") ??
                       "Server=muowdopceqgxjn2b3.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;Database=uzmhzrmllkprrfer;Uid=b7zjvc2wwna6iiph;Pwd=q3is20ce4ntrw416;Charset=utf8;Port=3306;SslMode=none";

// Register services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton(new DataService(connectionString));

// Register StudentService
builder.Services.AddScoped<StudentService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
