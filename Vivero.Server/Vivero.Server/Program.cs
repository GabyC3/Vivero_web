using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Vivero.BD.Datos;
using Vivero.BD.Datos.Entity;
using Vivero.Repositorio;
using Vivero.Server.Client.Pages;
using Vivero.Server.Components;
using Vivero.Servicio.ServicioHttp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ConnSqlServer")
    ?? throw new InvalidOperationException(
        "El string de conexion no existe");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IRepositorio<Producto>, Repositorio<Producto>>();
builder.Services.AddScoped<IRepositorio<Administrador>, Repositorio<Administrador>>();
builder.Services.AddScoped<IRepositorio<GestionProducto>, Repositorio<GestionProducto>>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient<IHttpServicio, HttpServicio>();

builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Vivero.Server.Client._Imports).Assembly);

app.MapControllers();
app.Run();

