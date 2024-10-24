using APIGateway.Controllers.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddAuthentication()
//    .AddJwtBearer("Bearer", options =>
//    {
//        options.RequireHttpsMetadata = false; // Dev için, prod'da true yapýn
//        options.Audience = "SingleOrDefault"; // Bu deðer JWT'de olmalý
//    });

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
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<RequestLoggingMiddleware>();
await app.UseOcelot();


app.MapControllers();

app.Run();
