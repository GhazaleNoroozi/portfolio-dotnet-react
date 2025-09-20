var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// CORS for React frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy => policy.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

// Middleware
app.UseCors("AllowReact");

app.UseAuthorization();

app.MapControllers(); // Map your controllers (e.g., HomeController)

app.Run();
