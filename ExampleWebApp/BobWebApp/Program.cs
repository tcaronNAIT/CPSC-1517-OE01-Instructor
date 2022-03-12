using Microsoft.EntityFrameworkCore;
using WestWindSystem;

var builder = WebApplication.CreateBuilder(args);

//setup the connection string service for the application
//1) retreive the connection string information from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("WWDB");

//2) register any "services" that are create in the class library you wish to use
// in our solution out services will be created (coded) in the class library WestWindSystem
// one services the setup of the database context (connection to the database)
// any other services will be created as the application requires.

// setup can be done here, locally
// setup can also be done elsewhere and called from this location *** this is the route we choose
builder.Services.WWBackendDependencies(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
//builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
