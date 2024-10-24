using Microsoft.AspNetCore.Mvc;
using BilgiLigiSecurityApi.DTOs;
using BilgiLigiSecurityApi.Extensions;
using BilgiLigiSecurityApi.Extensions.Attributes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
        response.Error = new ErrorResponse { Code = "400", Message = "Validasyon hatalar�n� kontrol edin" };

        return new BadRequestObjectResult(response);
    };
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = "SingleOrDefault",
            ValidAudience = "SingleOrDefault",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("2D4A614E645267556B58703273357638792F423F4428472B4B6250655368566D"))
        };
        o.Events = new JwtBearerEvents()
        {
            //OnAuthenticationFailed = c =>
            //{
            //    c.NoResult();
            //    c.Response.StatusCode = 500;
            //    c.Response.ContentType = "text/plain";
            //    return c.Response.WriteAsync(c.Exception.ToString());
            //},
            OnChallenge = context =>
            {
                context.HandleResponse();
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                var result = "You are not Authorized";
                return context.Response.WriteAsync(result);
            },
            OnForbidden = context =>
            {
                context.Response.StatusCode = 403;
                context.Response.ContentType = "application/json";
                var result = "You are not authorized to access this resource";
                return context.Response.WriteAsync(result);
            },
        };
    });
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
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
