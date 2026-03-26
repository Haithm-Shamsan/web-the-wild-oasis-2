using Api_WildOasis;
using Api_WildOasis.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Dependency Injection
builder.Services.AddAppDI();

// Add CORS service
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:5173") // Add your frontend's origin
                     .AllowAnyMethod()                     // Allow any HTTP method (GET, POST, etc.)
                     .AllowAnyHeader();                    // Allow any HTTP headers
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline for development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS globally
app.UseCors();

// Use HTTPS redirection for secure communication
app.UseHttpsRedirection();

// Authorization middleware
app.UseAuthorization();

// Map all controllers to handle API endpoints
app.MapControllers();

// Run the application
app.Run();
