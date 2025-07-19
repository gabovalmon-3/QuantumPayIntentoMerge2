var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5221", "https://localhost:5001");

// 2) Tus servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 3) ¡Importante!  
app.UseRouting();

app.UseAuthorization();

// 5) Luego mapea los controladores
app.MapControllers();

app.Run();