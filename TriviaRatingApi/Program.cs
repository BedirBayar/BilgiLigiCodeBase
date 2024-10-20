using TriviaRatingApi.Extensions;
using TriviaSecurityApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

var allowedOrigins = "_allowedOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddApplicationLayer();
builder.Services.AddTheDbContext();
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowedOrigins,
      builder =>
      {
          builder.WithOrigins("http://localhost:44319") // Frontend adresini ekleyin
                 .AllowAnyHeader() // Gerekli olan header'larý ekleyin, örneðin Content-Type
                 .AllowAnyMethod() // GET, POST gibi HTTP metotlarýný ekleyin
                 .AllowCredentials(); // Ýsterseniz cookie ve kimlik doðrulama bilgilerini ekleyebilirsiniz
      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
app.UseCors(allowedOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
