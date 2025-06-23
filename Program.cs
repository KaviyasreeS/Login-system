using HospitalSystemAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register DB + Controllers
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Hospital.db"));

builder.Services.AddControllers();
builder.Services.AddRazorPages(); // 👈 Add this line

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles(); // 👈 For serving CSS/JS if needed

app.UseRouting();

app.UseAuthorization();

app.MapControllers(); // API routes
app.MapRazorPages();  // Razor Pages routes

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
