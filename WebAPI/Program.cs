var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5221", "https://localhost:5001");

// 1) Añade CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowQuantumPay", policy =>
    {
        policy
          .WithOrigins("http://localhost:5000", "https://localhost:5000")
          .AllowAnyHeader()
          .AllowAnyMethod();
    });
});

// 2) Tus servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 3) ¡Importante!  
app.UseRouting();

// 4) Aplica la política CORS justo aquí  
app.UseCors("AllowQuantumPay");

app.UseAuthorization();

// 5) Luego mapea los controladores
app.MapControllers();

app.Run();