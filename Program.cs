using TimeStatisticsSystem.Helpers;
using TimeStatisticsSystem.Repositories;
using TimeStatisticsSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    builder.Services.AddSingleton<DataContext>();
    builder.Services.AddControllersWithViews();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // configure DI for application services
    builder.Services.AddScoped<IDayWorkRepository, DayWorkRepository>();
    builder.Services.AddScoped<IWorkInfoService, WorkInfoService>();
}

var app = builder.Build();

// ensure database and tables exist
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    await context.Init();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();
    
} else {
    // app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TimeStatisticsSystem v1"));
    app.UseCors();
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
