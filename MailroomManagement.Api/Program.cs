
using MailroomManagement.Api.Services;
using MailroomManagement.Api.Services.CloudServices;
using MailroomManagement.Api.Services.Interfaces;
using MailroomManagement.Api.Utilities;
using MailroomManagement.Core.Entities;
using MailroomManagement.Infrastructure.Data.MailroomManagement.Infrastructure.Data;
using MailroomManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Register repositories
builder.Services.AddScoped<IRepository<Organization>, Repository<Organization>>();
builder.Services.AddScoped<IRepository<Department>, Repository<Department>>(); // Use DepartmentRepository instead of Repository<Department>
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRepository<Letter>, Repository<Letter>>();

// Register services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ILetterService, LetterService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>(); // Ensure this line is present
builder.Services.AddScoped<ISetupService, SetupService>();
builder.Services.AddScoped<IUserService, UserService>();
// Register repositories
builder.Services.AddScoped<IRepository<Department>, Repository<Department>>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
// Register Cloud Services
builder.Services.AddSingleton<IS3Service, MockS3Service>(); // Register IS3Service with MockS3Service
builder.Services.AddSingleton<ISQSService, MockSQSService>();
builder.Services.AddSingleton<ILambdaService, MockLambdaService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

// Add services to the container.
// Add authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
