using Microsoft.AspNetCore.Mvc;
using BilgiLigiSecurityApi.DTOs;
using BilgiLigiSecurityApi.Extensions;
using BilgiLigiSecurityApi.Extensions.Attributes;

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
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(e => e.Value.Errors.Count > 0)
            .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );

        var response = new BaseResponse<Dictionary<string, string[]>>(errors);
        response.Success = false;
        response.Error = new ErrorResponse { Code = "400", Message = "Validasyon hatalarýný kontrol edin" };

        return new BadRequestObjectResult(response);
    };
});
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

app.UseCors(allowedOrigins);
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
