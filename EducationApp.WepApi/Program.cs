using App.Business.Services.ProductServices;
using App.Core.Security;
using EducationApp.DataAccess.Context;
using EducationApp.DataAccess.Repositories.ProductRepository;
using EducationApp.DataAccess.Repositories.RepositoryPattern;
using EducationApp.Entities.Concrete;
using EducationApp.Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region DbContext

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
options.UseSqlServer(builder.Configuration.GetConnectionString("KursDb"));
        

});

builder.Services.AddAuthentication().AddJwtBearer(options =>
{

    options.TokenValidationParameters = new()
    {

        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "baris",
        ValidAudience = "www.baris",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("deneme")),
        ClockSkew = TimeSpan.FromSeconds(60)


    };
});


#region Context Burasý Saðlýyor
builder.Services.AddIdentity<AppUser, AppRole>(option =>
{
option.User.RequireUniqueEmail = true;
option.Password.RequiredLength = 1;
option.Password.RequireNonAlphanumeric = true;
}).AddEntityFrameworkStores<ApplicationDbContext>(); 
#endregion

#endregion
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DependencyInjection
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>(); 
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();  
builder.Services.AddScoped<IJwtHandler,JwtHandler>();

#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


using (var scope=app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

#region hata mesajlarýný burda yakalýyoruz
app.Use(async (context, next) =>
{
try
{
await next(context);
}
catch (Exception ex)
{


context.Response.ContentType = "application/json";

        ErrorResponse errorResponse = new();
        errorResponse.Message = ex.Message;
        errorResponse.StatusCodeNumber = (int)HttpStatusCode.InternalServerError;
        errorResponse.StatusCode = HttpStatusCode.InternalServerError;
        string json=JsonSerializer.Serialize(errorResponse);
        await context.Response.WriteAsync(json);

    }
}); 
#endregion


app.Run();
