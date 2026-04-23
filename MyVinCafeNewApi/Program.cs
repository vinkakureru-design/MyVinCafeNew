using MyVinCafeNewLibrary.Data;
using Microsoft.EntityFrameworkCore;
using MyVinCafeNewApi.Feature.UserManagement;
using MyVinCafeNewApi.Feature.StuffManagement;
using MyVinCafeNewApi.Feature.MenuManagement;
using MyVinCafeNewApi.Feature.EmployeeManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Dependency Injection

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStuffService, StuffService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IEmployeService, EmployeeService>();


builder.Services.AddOpenApi();

var app = builder.Build();

app.UseMiddleware<MyVinCafeNewApi.Middleware.ErrorHandleMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(option =>
    {
        option.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
