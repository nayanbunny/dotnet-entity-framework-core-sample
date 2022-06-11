using DotNet.EFCore.CodeFirstFluentApi.MvcApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Adding Database Context to Web Application Builder Services Collection.
// This should be performed before building Web Application.
builder.Services.AddDbContext<EFCoreCodeFirstDatabaseContext>();

// Initializing Database and creating sample data
EFCoreCodeFirstDbInitializer.Initialize(new EFCoreCodeFirstDatabaseContext());

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
