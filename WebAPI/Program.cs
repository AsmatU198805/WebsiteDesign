using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using WebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// 1️⃣ Add Services
// --------------------

// Controllers
builder.Services.AddControllers();

// Swagger / OpenAPI (classic, not Minimal API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "Traditional WebAPI with Swagger"
    });
});

// EF Core: SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Optional: Blazor / HTTP client
builder.Services.AddRazorComponents()
       .AddInteractiveServerComponents();
builder.Services.AddHttpClient();

// --------------------
// 2️⃣ Build App
// --------------------
var app = builder.Build();

// --------------------
// 3️⃣ Configure Middleware
// --------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();           // Enable Swagger JSON
    app.UseSwaggerUI(c =>       // Enable Swagger UI
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        c.RoutePrefix = string.Empty; // Swagger UI at root: http://localhost:5175/
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Map your controllers
app.MapControllers();

// --------------------
// 4️⃣ Run App
// --------------------
app.Run();
