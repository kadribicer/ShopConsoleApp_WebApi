using Shop.ConsoleApp.Services.Abstract;
using Shop.ConsoleApp.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDiscountService, DiscountService>();

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddSwaggerDocument(opt =>
{
    opt.PostProcess = doc =>
    {
        doc.Info.Title = "Shop Discount API";
        doc.Info.Description = "API service for store discounts";
    };
});

var app = builder.Build();

app.UseDefaultFiles();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseOpenApi();

app.UseSwaggerUi3(s =>
{
    s.DocumentTitle = "Shop Discount API";
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});

app.Run();