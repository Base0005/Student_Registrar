using Registrar.Components;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using Dapper;
using Registrar.Services; 

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton(new DataService("Server=localhost;Database=Registrar;Uid=root;Pwd=;Charset=utf8;Port=3306;SslMode=none"));

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