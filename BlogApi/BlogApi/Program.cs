using BusinessLogicLayer.IService;
using BusinessLogicLayer.Service;
using DataAccessLayer.Data;
using DataAccessLayer.Data.IRepositories;
using DataAccessLayer.Repositories;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BlogApi.DataAccessLayer.Data;
using BlogApi.DomainLayer.Models;
using BusinessLogicLayer.MapperModel;
using DataAccessLayer.UnitOfWork;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.
    AddDbContext<ApplicationDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IAuthor, AuthorRepository>();
builder.Services.AddScoped<IBlog, BlogRepository>();
builder.Services.AddScoped<ICategory, CategoryRepository>();
builder.Services.AddScoped<IComment, CommentRepository>();

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddScoped<AuthorMapper>();
builder.Services.AddScoped<BlogMapper>();
builder.Services.AddScoped<CategoryMapper>();
builder.Services.AddScoped<CommentMapper>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = false;

    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

}).AddIdentity<User, Role>()
    .AddEntityFrameworkStores<ApplicationDBContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();

// JWT Configuration
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = key
    };
});

// Add Authorization
builder.Services.AddAuthorization();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

app.Run();
