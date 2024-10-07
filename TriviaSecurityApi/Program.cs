using TriviaSecurityApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = "_allowedOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddTheDbContext();
builder.Services.AddApplicationLayer();
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowedOrigins,
      builder =>
      {
          builder.WithOrigins("http://localhost:44319") // Frontend adresini ekleyin
                 .AllowAnyHeader() // Gerekli olan header'lar� ekleyin, �rne�in Content-Type
                 .AllowAnyMethod() // GET, POST gibi HTTP metotlar�n� ekleyin
                 .AllowCredentials(); // �sterseniz cookie ve kimlik do�rulama bilgilerini ekleyebilirsiniz
      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseCors(allowedOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
