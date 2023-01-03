using HellenicBankOpenAPI.Hellenic;
using HellenicBankOpenAPI.Models;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings>(
    builder.Configuration.GetSection(AppSettings.ConfigKey));

builder.Services
    .AddRefitClient<IHellenicClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(Clients.SandboxEndpoint));

builder.Services
    .AddRefitClient<ITokenClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(Clients.SandboxAuthEndpoint));


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// //Enables Logging of Http Requests
// var httpClient = new HttpClient(new HttpLoggingHandler()) {BaseAddress = new Uri(SERVER_URL)};
// RestService.For<YOUR_API>(httpClient);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();