using DevIO.App.Configurations;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

// Guardando a connection string do arquivo appSettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Adicionando o Identity
builder.Services.AddIdentityConfiguration(builder.Configuration);

// Adicionando o suporte ao acesso ao DB via EF
builder.Services.AddDbContext<MeuDbContext>(options => options.UseSqlServer(connectionString));

// Adicionando o AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Adicionando o MVC
builder.Services.AddMvcConfiguration();

// Resolvendo dependências
builder.Services.ResolveDependencies();

// Gerando a APP
var app = builder.Build();

// Configuração conforme os ambientes
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/erro/500");
    app.UseStatusCodePagesWithRedirects("/erro/{0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseGlobalizationConfig();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
